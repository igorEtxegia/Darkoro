using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelAJugar : MonoBehaviour
{
    public static NivelAJugar instancia;
    public int nuescena;
    public GameObject cambioEscena;

  

    public void CambiarAlMapa1()
    {
        nuescena = 2;
    }

    public void CambiarAlMapa2()
    {
        nuescena = 3;
    }
    public void CambiarAlMapa3()
    {
        nuescena = 4;
    }

    public void CambiarAlPuzzle()
    {
        nuescena = 5;
    }

    public void destruir()
    {
        Destroy(cambioEscena);

    }
}
    
