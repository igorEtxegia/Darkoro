using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Metodo que cambia al castellano
    public void CambiarIdiomaCastellano()
    {
        // le decimos al controlador de idioma que cambie el idioma
        ControladorIdiomas.instancia.CambiarIdioma(SystemLanguage.Spanish);
    }


    public void CambiarIdiomaEuskera()
    {
        // le decimos al controlador de idioma que cambie el idioma
        ControladorIdiomas.instancia.CambiarIdioma(SystemLanguage.Basque);
    }

    public void CambiarIdiomaIngles()
    {
        // le decimos al controlador de idioma que cambie el idioma
        ControladorIdiomas.instancia.CambiarIdioma(SystemLanguage.English);
    }
}
