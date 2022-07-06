using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguienteNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Comprobamos si es el jugador el que ha entrado
        if (collision.gameObject.tag == "Player")
        {
            //Indicamos al controlador que cargue el siguiente nivel
            GameManager.instancia.SiguienteNivel();
        }
    }
}
