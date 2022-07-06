using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que servira para que nos muestre un dialogo cuando el jugador interactue con algun objeto.
public class ObjetoInteractable3 : MonoBehaviour
{
    // Array donde guardaremos el texto del dialogo que tiene que mostrar.
    public Textos textos;
    // Variable que establece si el personaje debe estar quieto mientras el dialogo se mantenga.
    public bool pararPJ = false;
    // Variable que comprobara si el jugador acaba de pulsar la tecla E, para empezar con la interaccion.
    public bool comprobarTecla;


    // Update is called once per frame
    void Update()
    {
        // Comprobamos si el jugador ha pulsado la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // si ha pulsado la E, comprobarTecla sera verdadero
            comprobarTecla = true;
        } else if (Input.GetKeyUp(KeyCode.E))
        {
            // y si en cambio no ha pulsado la e, comprobarTecla sera falso
            comprobarTecla = false;
        }
    }


    // Metodo que se ejecutara cuando el jugador este colisionando contra el objeto que tiene este script
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Si mientras que se ejecuta este metodo estamos pulsando la E
        if (comprobarTecla == true)
        {
            //si no disponemos de las piezas del puzle
            if (AbrirPuertaThiff.piezaPuzle == 0)
            {
                // Nos mostrara un dialogo diciendo que no puede abrir la puerta
                // Detenemos al personaje
                PlayerController.instancia.PararPersonaje(pararPJ);
                // Usando el script ControlDialogos activamos el texto que hemos establecido desde el editor.
                FindObjectOfType<ControlDialogos>().ActivarCartel(textos);

            } else
            {
                // y si tiene piezas del puzle, no mostramos ningun dialogo.
                // Al usar las piezas del puzle se queda sin ellas.
                AbrirPuertaThiff.piezaPuzle -= 1;
            }

        }
    }
}
