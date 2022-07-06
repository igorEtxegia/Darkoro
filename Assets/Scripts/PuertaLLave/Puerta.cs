using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puerta : MonoBehaviour
{
    public GameObject nokey;
    public GameObject key;
    //Variable para comprobar si hemos pulsado la tecla E
    public bool comprobarTecla;

    public TextMeshProUGUI textoLlaves;
    private Animator _animPuerta;


    private void Start()
    {
        _animPuerta = GetComponentInChildren<Animator>();
        key.SetActive(false);
        nokey.SetActive(false);
      
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("key"))
        {
            AbrirPuerta.llave += 1;

            textoLlaves.text = AbrirPuerta.llave.ToString("x"+ AbrirPuerta.llave);
            Destroy(collision.gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Puerta") && AbrirPuerta.llave == 0)
        {
            nokey.SetActive(true);
        }

        if (collision.tag.Equals("Puerta") && AbrirPuerta.llave >= 1)
        {
            key.SetActive(true);
            if (comprobarTecla == true)
            {
                AbrirPuerta.llave -= 1;
                textoLlaves.text = AbrirPuerta.llave.ToString("x" + AbrirPuerta.llave);
                Destroy(collision.gameObject);
                //_animPuerta.SetBool("abrir",true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
            nokey.SetActive(false);
            key.SetActive(false);
        
    }
}
