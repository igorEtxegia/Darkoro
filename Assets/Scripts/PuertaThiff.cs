using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Para poder usar el control de escenas.
using UnityEngine.SceneManagement;

public class PuertaThiff : MonoBehaviour
{
    // Variable para verificar si hemos pulsado la tecla E
    public bool comprobarTecla;
    //public GameObject noPuzle;
    //public GameObject puzle;
    public bool mostrarDialogo =false;

   
    // En el momento de usar dialogos lo necesitare
    private void Start()
    {
        //noPuzle.SetActive(false);
        //puzle.SetActive(false);
    }


    // Metodo que se llama una vez por frame
    private void Update()
    {
        //if para verificar si el jugador a pulsado la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // hemos pulsado a la E, por lo tanto
            comprobarTecla = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            //No estamos pulsando la E, por tanto...
            comprobarTecla = false;
        }
    }


    // Metodo que se ejecuta cuando entramos en la colision, es decir, cuando cogemos las piezas del puzle.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el objeto con el que se ha producido la colision tiene una etiqueta de "Puzle"..
        if (collision.tag.Equals("Puzle"))
        {
            // Añadimos que tenemos las piezas del puzle
            AbrirPuertaThiff.piezaPuzle += 1;
            // Destruimos el objeto con el que hemos colisionado ya que el personaje ha cogido las piezas del puzle.
            Destroy(collision.gameObject);
        }
    }


    // Metodo que se ejecuta mientras estamos cerca de la colision, en este caso para poder interactuar con la puerta
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Comprobamos si el personaje esta frente a la puerta y si ha pulsado la E.
        if (collision.gameObject.tag == "PuertaPuzle" && comprobarTecla)
        {
            // Si disponemos de las piezas del puzle...
            if (AbrirPuertaThiff.piezaPuzle >= 1)
            {
                //puzle.SetActive(true);
                Scene escenaActual = SceneManager.GetActiveScene();
                // Cargamos la escena del puzle
                SceneManager.LoadScene("scn_puzle");
            } else
            {
                //No disponemos de las piezas del puzle. Nos mostrara un dialogo. 
                //noPuzle.SetActive(true);
            }

        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {

        //noPuzle.SetActive(false);
        //puzle.SetActive(false);

    }
}
