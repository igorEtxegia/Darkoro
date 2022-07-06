using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//No va a estar ascociado a ningun objeto
public class Textos
{
    [TextArea(2, 6)]//Ocupara de 2 a 6 lineas
    public string[] arrayTextos; //Array que contendra los textos
    public string[] arrayNombres; //Array que contendra los textos
}
