using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision) // Cuando el jugador entre en el trigger
    {
        if (collision.CompareTag("Player"))
        {
            
            RocaCaer.instancia.gravedad();
            AudioManager.instance.PararTodoAudio(); // Paramos todos los audios
            AudioManager.instance.PlayAudio(AudioManager.instance.derrumbe); // Iniciamos el sonido del derrumbe
            AudioManager.instance.PlayAudio(AudioManager.instance.musicMapaCave); // Iniciamos el audio de la entrada a la cueva
            
        }
    }
}
