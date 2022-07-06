using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Rigidbody2D rb;
    Enemy enemy;
    public bool isDamaged;
    private Animator _animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        enemy = GetComponent<Enemy>();
    }

    //Metodo para cuando un trigger entra en contacto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si la colision contiene el tag Weapon y aun no a sido dañado restamos 2 puntos de vida al enemigo
        if (collision.CompareTag("Weapon") && !isDamaged)
        {
            _animator.SetTrigger("Sufre");
            enemy.healthPoints -= 2f;
            if(collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            
            StartCoroutine(Damager());
        }

        //Si el enemigo tiene 0 o menos vida lo destruimos
        if(enemy.healthPoints <= 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            _animator.SetTrigger("Muerte");
            StartCoroutine(Desaparecer());
        }
    }

    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    //Corrutina que cuando el enemigo es golpeado espera medio segundo para que este pueda volver a ser golpeado
    IEnumerator Damager()
    {
        isDamaged = true;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
    }
}
