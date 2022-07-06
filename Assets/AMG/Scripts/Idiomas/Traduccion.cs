using System; // lo necesitamos para poder serializar
using UnityEngine;


// Indicamos a unity que esta clase puede salir en el inspector
[Serializable]
//Clase que indica una traduccion
public class Traduccion
{
    // Clave que hace referencia a la traducción
    public string clave;
    [TextArea]
    // Campo con la traduccion del texto
    public string valor;
}
