using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperarVida : MonoBehaviour
{
    public float heal = 6;
    public bool comprobarTecla;

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

        if (comprobarTecla == true)
        {
            PlayerStats.Instance.Heal(heal);
        }

    }
}
