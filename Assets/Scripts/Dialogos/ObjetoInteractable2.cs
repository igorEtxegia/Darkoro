using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Clase para que se ejecute cuando el jugador interactue con Thiff habra un dialogo y cambio de arma.
public class ObjetoInteractable2 : MonoBehaviour
{
    public Textos textos;
    public bool pararPJ = true;
    public bool comprobarTecla;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            comprobarTecla = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            comprobarTecla = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (comprobarTecla == true)
        {
            //Buscaremos en el objeto el control de dialogos
            PlayerController.instancia.PararPersonaje(pararPJ);
            FindObjectOfType<ControlDialogos>().ActivarCartel(textos);
            PlayerController.instancia.CambioDeArma();
        }

    }

}
