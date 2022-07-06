using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    private Animator _animator;
    public GameObject fin;
    public bool pararPJ = true; // Variable para parar el personaje

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

   
    private void OnTriggerEnter2D(Collider2D collision) // Cuando el jugador entre en el trigger
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.PararTodoAudio(); // Paramos todos los audios
            AudioManager.instance.PlayAudio(AudioManager.instance.musicWin); // Iniciamos el audio de la musica ganadora
            PlayerController.instancia.PararPersonaje(pararPJ); // Paramos al personaje
            _animator.SetBool("Fin", true); // Ejecutamos la animacion
        }
    }

    public void Quit()
    {
        Application.Quit(); // Cerramos el juego
    }
}
