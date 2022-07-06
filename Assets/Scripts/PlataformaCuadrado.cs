using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCuadrado : MonoBehaviour
{
    public GameObject ObjetoAmover;

    public Transform StartPoint;
    public Transform EndPoint;
    public Transform SecondPoint;
    public Transform TercerPoint;

    public float Velocidad;

    private Vector3 MoverHacia;


    // Start is called before the first frame update
    void Start()
    {
        MoverHacia = SecondPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, Velocidad * Time.deltaTime);

        

        if (ObjetoAmover.transform.position == StartPoint.position)
        {
            MoverHacia = SecondPoint.position;
        }

        if (ObjetoAmover.transform.position == SecondPoint.position)
        {
            MoverHacia = TercerPoint.position;
        }

        if (ObjetoAmover.transform.position == TercerPoint.position)
        {
            MoverHacia = EndPoint.position;
        }
        
        if (ObjetoAmover.transform.position == EndPoint.position)
        {
            MoverHacia = StartPoint.position;
        }

    }
}
