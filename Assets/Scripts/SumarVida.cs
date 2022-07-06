using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumarVida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats.Instance.AddHealth();
            Destroy(gameObject);

        }
    }
}
