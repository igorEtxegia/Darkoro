using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Indicamos el menu desde el que se pueden crear nuevos idiomas
[CreateAssetMenu(fileName = "nuevo idioma", menuName = "Idiomas", order = 0)]
public class Idioma : ScriptableObject
{
    // Idioma al que van destinadas las traducciones
    public SystemLanguage idioma;
    // Lista con todas las traducciones para el idioma
    public List<Traduccion> traducciones;
}
