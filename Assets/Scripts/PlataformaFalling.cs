using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaFalling : MonoBehaviour
{
    public float fallDelay = 1f;
    public float respawnDelay = 5f;

    private Rigidbody2D rb;
    private PolygonCollider2D _pc2d;
    private Vector3 start;


   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _pc2d = GetComponent<PolygonCollider2D>();
        start = transform.position;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    private void Fall()
    {
        rb.isKinematic = false;
        _pc2d.isTrigger = true;
    }

    private void Respawn()
    {
        transform.position = start;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        _pc2d.isTrigger = false;
    }
}
