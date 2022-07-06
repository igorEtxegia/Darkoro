using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo2D : MonoBehaviour
{
    public bool golpeado;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && golpeado == false)
        {
            PlayerStats.Instance.TakeDamage(0.25f);
            golpeado = true;
            StartCoroutine(GolpeoAespera());

        }
    }

    IEnumerator GolpeoAespera()
    {
        yield return new WaitForSeconds(1);
        golpeado = false;
    }
}
