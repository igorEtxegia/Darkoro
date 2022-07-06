using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{   
    

    private Animator _animator;
    private bool _prueba = true;
    public bool comprobarTecla;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            comprobarTecla = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            comprobarTecla = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            
            if (comprobarTecla == true && _prueba)
            {
                Debug.Log("Bajando...");
                _animator.SetBool("Bajar", true);
                _animator.SetBool("Subir", false);
                StartCoroutine(Bajando());
                
            }

            if (comprobarTecla == true && _prueba == false)
            {
                Debug.Log("Subiendo...");
                _animator.SetBool("Bajar", false);
                _animator.SetBool("Subir", true);
                StartCoroutine(Subiendo());

            }
        }
    }

 
    IEnumerator Bajando()
    {
        yield return new WaitForSeconds(10);
        _prueba = false;
    }

    IEnumerator Subiendo()
    {
        yield return new WaitForSeconds(10);
        _prueba = true;
    }
}

