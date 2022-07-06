using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosCofres : MonoBehaviour
{
    public Textos textos;
    //Variable del objeto que contendra el cofre
    public GameObject chestItem;
    //Variable para comprobar si el personaje a de quedarse quieto
    public bool pararPJ = true;
    //Variable para comprobar si es un cofre que contendra un objeto
    public bool cofreConObjeto; 
    //Variable para comprobar si hemos pulsado la tecla E
    public bool comprobarTecla;
    private Animator _animator;
    //Variable para comprobar si el cofre esta abiero o no.
    private bool _abierto = false;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        //if para verificar si el jugador a pulsado la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            comprobarTecla = true;
        }else if (Input.GetKeyUp(KeyCode.E))
        {
            comprobarTecla = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Si el juagdor a pulsado sobre la tecla E y el cofre esta cerrado
        if (comprobarTecla == true && _abierto == false)
        {
            //Marcamos como abierto
            _abierto = true;
            //Llamaos al metodo para parar nuestro personaje
            PlayerController.instancia.PararPersonaje(pararPJ);
            //Ejecutamos la aniamcion del cofre
            _animator.SetBool("Open", true);
            //Llamaos al metodo para activar el dialogo
            FindObjectOfType<ControlDialogos>().ActivarCartel(textos);
            //Si el cofre contiene algun objeto llamamos a la corrutina
            if(cofreConObjeto == true)
            {
                StartCoroutine(GetChestItem());
            }
        }
        
        if(_abierto == true)
        {
            comprobarTecla = false;
        }
    }

    //Corrutina que espera 1 segundo para poder entregarte el objeto
    private IEnumerator GetChestItem()
    {
        yield return new WaitForSeconds(1);
        Instantiate(chestItem, transform.position, Quaternion.identity);
       
    }
}
