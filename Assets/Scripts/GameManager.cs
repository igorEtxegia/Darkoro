using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Setencia using para la carga de escenas
using UnityEngine.SceneManagement;
// Sentencia using para el TextMeshPro
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Variable estatica con el GameManager que lo hara accesible desde cualquier lado del jeugo
    public static GameManager instancia;
    public PlayerController jugador;
    public CameraController camera;
    //Variable que indica el tiempo de guardado a esperar antes de recolocar el jugador cuando este haya muerto
    public float tiempoReaparicion = 2;
    public int vidas = 3;
    public GameObject respawn;
    private Animator _animator;
    private Rigidbody2D _rigibody;
    // Variables con las cajas de texto de información del juego
    public TextMeshProUGUI textoNivel, textoNivel2, textoNivel3;
    // Variable que contiene la información del nivel
    private Nivel _nivel;
    public int numeroEscena;
    private NivelAJugar genericScript;
    public GameObject imagenCarga;
    public TextMeshProUGUI textCarga, textCarga2, textCarga3;

    private void Awake()
    {
        genericScript = FindObjectOfType<NivelAJugar>(); // Buscamos al escena que tiene que jugar y la guardamos en una variable
    }

    private void Start()
    {
       
        _rigibody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        //Comprobamos si la variable de instancia tiene algun valor
        if (instancia == null)
        {
            //Damos valor a la variable estatica
            instancia = this;
            //Evitamos que el objeto se destrulla con el cambio de escenas
            DontDestroyOnLoad(gameObject);
            //Cargamos la escena del juego
            SceneManager.LoadScene(genericScript.nuescena);
            AudioManager.instance.PararTodoAudio(); // Paramos todos los audios

        }
        else
        {
            //Ya existe un GameManager en el juego,destruimos este
            Destroy(gameObject);
        }

        
    }

    // Método que recibe la información del nivel a jugar
    public void OnIniciarNivel(Nivel nuevoNivel)
    {
        
        //textoNivel.text = "Mapa " + (SceneManager.GetActiveScene().buildIndex -1);
        // Asignamos la variable que contiene la información
        // del nivel
        _nivel = nuevoNivel;
     
        // Disponemos de la información del nivel, recolocamos
        // el jugador
        RecolocarJugador();
        imagenCarga.SetActive(true);  // Activamos la imagen de carga y ejecutamos su animacion
        _animator.Play("ImagenCargaMapa");
        Scene escenaActual = SceneManager.GetActiveScene(); // Guardamos en una variable la escena actual y comprobamos en que escena estamos
        if (escenaActual.buildIndex == 2) 
        {
            
            AudioManager.instance.PlayAudio(AudioManager.instance.musicMapa1); // Iniciamos el sonido/musica
            AudioManager.instance.PlayAudio(AudioManager.instance.tormenta); // Iniciamos el sonido/musica
            textCarga.enabled = true; // Activamos/desactivamos los componentes TextMeshProUGUI
            textoNivel.enabled = true;
            textoNivel2.enabled = false;
            textoNivel3.enabled = false;
        }
        else if (escenaActual.buildIndex == 3)
        {
            camera.ModificarCamara2(); // Llamaos al metodo que posicionara la camara
            AudioManager.instance.PlayAudio(AudioManager.instance.musicMapa2); // Iniciamos el sonido/musica
            textCarga2.enabled = true; // Activamos/desactivamos los componentes TextMeshProUGUI
            textoNivel.enabled = false;
            textoNivel2.enabled = true;
        }
        else if (escenaActual.buildIndex == 4)//Si la escena actual es el mapa 3
        {
            AudioManager.instance.PararTodoAudio();
            camera.ModificarCamara(); // Llamaos al metodo que posicionara la camara
            AudioManager.instance.paraMusicaPuzzle();
            AudioManager.instance.PlayAudio(AudioManager.instance.musicMapa3); // Iniciamos el sonido/musica
            textCarga3.enabled = true; // Activamos/desactivamos los componentes TextMeshProUGUI
            textoNivel.enabled = false;
            textoNivel2.enabled = false;
            textoNivel3.enabled = true;
        }
        StartCoroutine(EscenaDeCarga());
    }


    IEnumerator EscenaDeCarga()
    {
        yield return new WaitForSeconds(5); // Esperamos 5 segundos
        imagenCarga.SetActive(false); // Desactivamos la imagen de carga
        textCarga.enabled = false; // Desactivamos los componentes TextMeshProUGUI
        textCarga2.enabled = false;
        textCarga3.enabled = false;
    }

    // Método para recolocar el jugador en el escenario
    private void RecolocarJugador()
    {
        // Cambiamos la posición del jugador a la que nos dicen
        // en la información del nivel
        jugador.transform.position = _nivel.puntoInicial.position;
        // Habilitamos el script del jugador
        jugador.enabled = true;
    }

    //Metodo encargado de cargar el siguiente nivel si es que lo hay
    public void SiguienteNivel()
    {
        AudioManager.instance.PararTodoAudio();
        //Obtenemos la escena actual
        Scene escenaActual = SceneManager.GetActiveScene();
        //Comprobamos si el indice de la escena actual es menor que toda la cantidad de escenas que hay en el juego
        if (escenaActual.buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            //Indicamos que se cargue el siguiente nivel
            SceneManager.LoadScene(escenaActual.buildIndex + 1);
        }
        else
        {
            // Salimos del juego
            Application.Quit();
        }
    }


    public void JuegoAcabado()
    {
        //Destroy(gameObject);
        AudioManager.instance.PararTodoAudio(); // Paramos todos los audios
        AudioManager.instance.PlayAudio(AudioManager.instance.musicGameOver); // Iniciamos la musica del GameOver
        SceneManager.LoadScene("GameOver"); // Cargamos la escena GameOver
    }

    public IEnumerator OnJugadorMuerto()
    {
        
        //Esperamos el tiempo antes de recolocar el jugador
        yield return new WaitForSeconds(tiempoReaparicion);
        _animator.SetBool("Die", false);
        //Deshabilitamos el script
        jugador.enabled = true;
        
       
        //Comporbamos cuantas vidas nos quedan
        if (vidas >= 0)
        {
            
            jugador.transform.position = respawn.transform.position; // Posicionamos al personaje
        }
        else
        {
            //No tenemos vidas, el juego a acabado
            //Obtenemos el indice de compilacion de la escena activa
            int indiceEscena = SceneManager.GetActiveScene().buildIndex;
            //Recargamos la escena en la que nos encontramos
            SceneManager.LoadScene(indiceEscena);
        }
    }
    public void Emparentar(Transform objeto)
    {
        objeto.SetParent(transform); // Hacemos que el jugador se haga hijo del objeto
    }


}
