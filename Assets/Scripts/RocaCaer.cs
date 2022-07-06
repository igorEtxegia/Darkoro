using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaCaer : MonoBehaviour
{
    private Rigidbody2D rb;
    public static RocaCaer instancia;
    public GameObject bloqueo;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }





    public void gravedad()
    {
      
        rb.isKinematic = false;
        bloqueo.SetActive(true);
    }
}
