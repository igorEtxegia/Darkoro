using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Clase para que se ejecute un dialogo cuando llegas a una zona determinada del mapa, se hace automaticamente
public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;
    public bool pararPJ = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Entro en el trigger");
            //Buscaremos en el objeto el control de dialogos
            PlayerController.instancia.PararPersonaje(pararPJ);
            FindObjectOfType<ControlDialogos>().ActivarCartel(textos);
            Destroy(gameObject);
        }

        
    }

}