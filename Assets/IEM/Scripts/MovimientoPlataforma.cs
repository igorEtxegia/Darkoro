using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public GameObject tronco; //la plataforma tronco que se mueve

    //Declaramos los dos puntos donde se mueve el tronco
    public Transform startPoint;
    public Transform endPoint;

    public float velocidad; //la velocidad a la que se mueve el tronco de un punto al otro.

    private Vector3 _direccion; //variable que indica hacia donde nos queremos mover


    // Start is called before the first frame update
    void Start()
    {
        _direccion = endPoint.position; //de inicio fijamos que se mueva a la posicion final.
    }

    // Update is called once per frame
    void Update()
    {
        tronco.transform.position = Vector3.MoveTowards(tronco.transform.position, _direccion, velocidad * Time.deltaTime); //movemos el tronco desde el punto de partida hasta el punto final.

        //Comprobamos si el tronco esta en el punto final si es asi cambiamos la direccion al punto inicio para que se mueva y viceversa.
        if (tronco.transform.position == endPoint.position)
        { 
            _direccion = startPoint.position;

        } else if (tronco.transform.position == startPoint.position)
        {
            _direccion = endPoint.position;
        }
    }
}
