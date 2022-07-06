using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    float x =180;
    void Update()
    {
        x -= Time.deltaTime * 50;
        transform.rotation = Quaternion.Euler(0, 0, x);
    }
}
