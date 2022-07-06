using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorIdiomas : MonoBehaviour
{
    // Variable estatica con el controlador de idiomas
    public static ControladorIdiomas instancia;
    // Variabke que indica el idioma actual
    public SystemLanguage idiomaActual;
    // Lista con todos los idiomas disponibles
    public List<Idioma> idiomas;
    // Variable que contiene la starducciones para el idioma actual
    private Idioma _traduccionesIdioma;

    
    private void Awake()
    {
        // Si existe ya una instancia lo destruimos
        if (instancia) Destroy(gameObject);
        else
        {
            // Asiganamos este objeto como instancia
            instancia = this;
            // Evitamos que el objeto se destruya
            DontDestroyOnLoad(gameObject);
            // Indicamos a unity que cuando se active una escena tiene que ir a un metodo concreto
            SceneManager.activeSceneChanged += OnEscenaActivada;
        }
        // Intentamos asignar por defecto el idioma guardado
        if(!ObtenerIdioma(CargarPreferenciasIdioma(), out _traduccionesIdioma))
        {
            // Si no encontramos un idioma asignamos uno por defecto
            ObtenerIdioma(idiomaActual, out _traduccionesIdioma);
        }
        else
        {
            // Tenemos traducciones en el idioma del sistema, cambiamso el idioma actual
            idiomaActual = _traduccionesIdioma.idioma;
        }
    }

    // Metodo que nos permite cambair a un nuevo idioma
    public void CambiarIdioma(SystemLanguage nuevoIdioma)
    {
        //Comprobamos que no estamos cambiando al mismo idioma
        if(nuevoIdioma != idiomaActual)
        {
            //Asignamos el nuevo idioma
            idiomaActual = nuevoIdioma;
            //Obtenemos las traducciones para el nuevo idioma
            ObtenerIdioma(idiomaActual, out _traduccionesIdioma);
            //Llamamos al metodo traducir la escena
            TraducirEscena();
            // Guardamos el uevo idioma
            GuardarPreferenciasIdioma();

        }
    }

    // Metodo que guarda las preferencias de idioma
    private void GuardarPreferenciasIdioma()
    {
        // Convertimos el valor del idioma actual a un numero
        int idioma = (int)idiomaActual;
        // Guardamos el idioma actual en la clase PlayerPrefs
        PlayerPrefs.SetInt("Idioma", idioma);
    }

    // Funcion que carga las preferencias de escena
    private SystemLanguage CargarPreferenciasIdioma()
    {
        //Obtenemos el idioma guardado previamente
        int idioma = PlayerPrefs.GetInt("Idioma", (int)Application.systemLanguage);
        // Devolvemos el numero convertido a una enumeracion
        return (SystemLanguage)idioma;
    }

    // Metodo que se lanza cuando se ha activado una escena
    private void OnEscenaActivada(Scene anterior, Scene siguiente)
    {
        // Llamamos al metodo que traduce la escena
        TraducirEscena();
    }

    // Funcion que busca un idioma y si lo encuentra asigna sus traduciones
    private bool ObtenerIdioma(SystemLanguage idioma, out Idioma traducciones) 
    {
        // Indicamos un valor inicial para la variable de salida
        traducciones = null;
        // Recorremos todos los idiomas existentes
        foreach(Idioma i in idiomas)
        {
            // Comprobamos si el idioma buscado esta entre los disponibles
            if(i.idioma == idioma)
            {
                //Asignamos las traducciones del idioma
                traducciones = i;
                //Devolvemos que hemos encontrado el idioma
                return true;
            }
        }
        // No hemos encontrado ningun idioma
        return false;
    }

    // Funcion que busca una traduccion
    public string TraducirElemento(string clave)
    {
        // Recorremos todas las traducciones en el idioma actual
        foreach(Traduccion traduccion in _traduccionesIdioma.traducciones)
        {
            // Comprobamos si alguna de las claves coincide con la que buscamos
            if(traduccion.clave.ToUpper() == clave.ToUpper())
            {
                // Devolvemos la traduccion de la clave
                return traduccion.valor;
            }
        }
        //No hemos encontrado la clave
        return null;
    }

    // Metodo para traducir la escena actual
    private void TraducirEscena()
    {
        // Recuperamos todas las cajas de texto de la escena
        TextMeshProUGUI[] textos = FindObjectsOfType<TextMeshProUGUI>(true);//el true sirve para recuperar los objetos que no esten activos en la escena tb
        // Recorremos todas las cajas de texto de la escena
        foreach( TextMeshProUGUI texto in textos)
        {
            // Obtenemos las traduccion de la caja de texto
            string traduccion = TraducirElemento(texto.name);
            // Si tenemos algun valor de traduccion, sustituimos el texto
            if (!string.IsNullOrEmpty(traduccion)) texto.text = traduccion;
        }
    }
}
