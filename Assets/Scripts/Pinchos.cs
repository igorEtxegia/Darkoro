using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    public float _dmgPinchos = 1;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Restamos una vida
            PlayerStats.Instance.TakeDamage(_dmgPinchos);
            
            StartCoroutine(PlayerController.instancia.MuerteJugador());
        }
    }
}
