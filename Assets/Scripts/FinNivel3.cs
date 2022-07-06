using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinNivel3 : MonoBehaviour
{
    
    public GameObject panel;
    public bool pararPJ = true;
    //Variable para comprobar si hemos pulsado la tecla E
    public bool comprobarTecla;

    private void Update()
    {
        //if para verificar si el jugador a pulsado la tecla E
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
            PlayerController.instancia.PararPersonaje(pararPJ);
            panel.SetActive(true);
            
            
        }
    }

    public void CerrarPanel()
    {
        pararPJ = false;
        panel.SetActive(false);
        PlayerController.instancia.PararPersonaje(pararPJ);
    }
}
