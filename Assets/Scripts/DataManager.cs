using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instancia;

    private void Awake()
    {
        if(instancia == null)
        {
            instancia = this;
        }
        else if(instancia != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    //Metodo Para almacenar los valores de la musica
    public void MusicData(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    //Metodo Para almacenar los valores de los sonidos
    public void SfxData(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

   /* //Metodo Para almacenar las vidas actuales que tenemos
    public void CurrentHearts(float value)
    {
        PlayerPrefs.SetFloat("heartsAmount", value);
    }

    //Metodo Para almacenar las vidas actuales que tenemo
    public void MaxHearts(float value)
    {
        PlayerPrefs.SetFloat("maxHearts", value);
    }
   */
    

}
