using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPinchosRio : MonoBehaviour
{

    public Transform plataforma;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Voltear(plataforma.transform.rotation.z));
    }

    public IEnumerator Voltear(float rotacion)
    {
       
        
        
        
        yield return new WaitForSeconds(3);
         plataforma.transform.rotation = Quaternion.Euler(0, 0, rotacion);
        if (rotacion == 0) StartCoroutine(Voltear(-180));
        else StartCoroutine(Voltear(0));
    }
    
   
}
