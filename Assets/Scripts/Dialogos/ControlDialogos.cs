using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlDialogos : MonoBehaviour
{   
    private Animator _animator;
    private Queue <string> colaDialogos = new Queue<string>();
    private Queue <string> colaNombres = new Queue<string>();
    Textos texto;
    Textos nombre;
    public GameObject imagen;
    public Sprite Protagonista;
    public Sprite Herrero;
    public Sprite viejo;
    public Sprite info;
    [SerializeField] TextMeshProUGUI textoPantalla;
    [SerializeField] TextMeshProUGUI nombrePantalla;
    public bool pararPJ = false;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        //imagen = GetComponent<Image>().sprite;
    }

    public void ActivarCartel(Textos textoObjeto)
    {
        textoPantalla.text = " ";
        _animator.SetBool("Cartel", true);
        texto = textoObjeto;
        nombre = textoObjeto;
        //ActivaTexto()
    }

    //Metodo para reproducir los textos de la cola
    public void ActivaTexto()
    {
        //Borramos la cola
        colaDialogos.Clear();
       
        //Metemos todos los textos en el array que tocan salir
        foreach(string textoGuardar in texto.arrayTextos)
        {
            colaDialogos.Enqueue(textoGuardar);
        }
       
        //Llamamos a  otro metodo
        SiguienteFrase();
    }

    public void ActivaNombres()
    {
        //Borramos la cola
        colaNombres.Clear();
        //Metemos todos los textos en el array que tocan salir
        
        foreach (string nombreGuardar in nombre.arrayNombres)
        {
            colaNombres.Enqueue(nombreGuardar);
        }
        //Llamamos a  otro metodo
        SiguienteNombre();
    }


    public void SiguienteFrase()
    {
        //Si en la cola es igual a 0 cerramos el cartel
        if (colaDialogos.Count == 0)
        {
            CierraCartel();
            return;
        }
        //Si en la cola hay algun texto añadirmos el texto que toca
        string fraseActual = colaDialogos.Dequeue();
       
        //textoPantalla.text = fraseActual;
        textoPantalla.text = ControladorIdiomas.instancia.TraducirElemento(fraseActual);


    }

    public void SiguienteNombre()
    {
        //Si en la cola hay algun texto añadirmos el texto que toca
        if (colaNombres.Count == 0)
        {
            CierraCartel();
            return;
        }
        string nombreActual = colaNombres.Dequeue();
        ComprobarNombre(nombreActual);
        nombrePantalla.text = nombreActual;
    }

    public void ComprobarNombre(string nombreActual)
    {
        if (nombreActual == "Darkoro")
        {
            imagen.GetComponent<Image>().sprite = Protagonista;

        }
        else if (nombreActual == "Thiff" || nombreActual == "??????")
        {
            imagen.GetComponent<Image>().sprite = Herrero;
        }
        else if (nombreActual == "Viejo")
        {
            imagen.GetComponent<Image>().sprite = viejo;
            
        }
        else if (nombreActual == "Info")
        {
            imagen.GetComponent<Image>().sprite = info;

        }
        else
        {
            Debug.Log("No se han encontrado personas");
        }
    }

    private void CierraCartel()
    {
        Debug.Log("Cierro cartel");
        _animator.SetBool("Cartel", false);
        PlayerController.instancia.PararPersonaje(pararPJ);
        
    }
}
