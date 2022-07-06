using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public GameObject follow;
    public Camera camara;
    public Vector2 minCamPos, maxCamPos;
    public float smoothTime;

    private Vector2 _velocity;

    private void Start()
    {
        camara = GetComponent<Camera>();
    }
    // Metodo para laposicion de la camara en el mapa 3
    public void ModificarCamara()
    {
        camara.orthographicSize = 15f;//Zoom
        minCamPos.y = -240f;

        maxCamPos.x = 1957f;
        maxCamPos.y = -30f;     
    }

    // Metodo para laposicion de la camara en el mapa 2
    public void ModificarCamara2()
    {
        camara.orthographicSize = 15f;//Zoom
        minCamPos.x = -124.65f;
        minCamPos.y = -145f;
       
        maxCamPos.x = 2000f;
        maxCamPos.y = 29.1f;

        //transform.position = new Vector3(transform.position.x, -3f , transform.position.z); intento de que la camara se vea un poco mas arriba de lo que esta.
    }

    private void FixedUpdate()
     {
         float posX = Mathf.SmoothDamp(transform.position.x,
             follow.transform.position.x,
             ref _velocity.x, smoothTime);
         float posY = Mathf.SmoothDamp(transform.position.y,
             follow.transform.position.y,
             ref _velocity.y, smoothTime);

         transform.position = new Vector3(
             Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
             Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
             transform.position.z);
    }
}

