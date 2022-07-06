using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform resPawn;
    public float dmg;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {       
            if (resPawn)
            {
                PlayerStats.Instance.TakeDamage(dmg);
                collision.gameObject.transform.position = resPawn.transform.position;
            }
            else
            {
                PlayerStats.Instance.TakeDamage(dmg);
            }
            
        }
    }
}
