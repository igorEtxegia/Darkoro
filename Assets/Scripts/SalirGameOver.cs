using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirGameOver : MonoBehaviour
{
    //Variable para comprobar si el personaje a de quedarse quieto
    public bool pararPJ = true;

    private void Start()
    {
        AudioManager.instance.PararTodoAudio(); // Paramos todos los audios
        AudioManager.instance.PlayAudio(AudioManager.instance.musicGameOver); // Iniciamos el audio de la musica cuando pierdes
                                                                              //Llamaos al metodo para parar nuestro personaje
        PlayerController.instancia.PararPersonaje(pararPJ);
    }


    public void GoToMainMenu()
    {
        AudioManager.instance.PararTodoAudio();
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("SelectorDeNivel"));
        
        SceneManager.LoadScene(0);
    }


    public void Quit()
    {
        Application.Quit(); // Para salir del juego
    }
}
