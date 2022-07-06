using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pajaro : MonoBehaviour
{
    public GameObject objetoAmover;

    public Transform startPoint;
    public Transform endPoint;

    public float velocidad;

    private Vector3 moverHacia;

    private void Start()
    {
        moverHacia = endPoint.position;
    }

    private void Update()
    {
        objetoAmover.transform.position = Vector3.MoveTowards(objetoAmover.transform.position, moverHacia, velocidad * Time.deltaTime);

        if(objetoAmover.transform.position == endPoint.position)
        {
            
            moverHacia = startPoint.position;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (objetoAmover.transform.position == startPoint.position)
        {
            moverHacia = endPoint.position;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

}
