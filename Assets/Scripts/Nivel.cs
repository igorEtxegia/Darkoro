using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : MonoBehaviour
{
    // Variable que indica el lugar donde tiene que aparecer
    // el personaje al iniciar el nivel.
    public Transform puntoInicial;
    

    private void Start()
    {
        // Enviamos al controlador de juego, la información
        // del nivel a jugar
        Debug.Log(this);
        GameManager.instancia.OnIniciarNivel(this);
    }

}
