using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : MonoBehaviour
{

    public GameObject ObjetoAmover;
    public Transform StartPoint;
    public Transform EndPoint;
    public bool destruido = false;

    public float Velocidad;
    private Vector3 MoverHacia;

    void Start()
    {
        MoverHacia = EndPoint.position;

    }

    // Update is called once per frame
    void Update()
    {

        if(destruido == true)
        {
          
            ObjetoAmover.transform.position = StartPoint.position;
            destruido = false;
        }
        else
        {
            ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, Velocidad * Time.deltaTime);

            if (ObjetoAmover.transform.position == EndPoint.position)
            {
                //MoverHacia = StartPoint.position;
                // ObjetoAmover.transform.position = StartPoint.position;
                destruido = true;
            }

            if (ObjetoAmover.transform.position == StartPoint.position)
            {

                MoverHacia = EndPoint.position;
            }
        }



        
    }
}
