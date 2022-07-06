using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //Damos acceso a los Mixer de audio creados
    public AudioMixer musicMixer, effectsMixer;
    //Creamos los audioSource para asignarles los diferentes audios a cada uno
    public AudioSource tormenta, mainMenuMusic, musicMapa1, derrumbe, musicMapaCave, musicMapa2, musicMapa3, musicGameOver, musicWin, musicPuzzle, impact, ramaImpact;
   

    public static AudioManager instance;

    [Range(-80,10)]
    public float masterVol, effectsVol;
    public Slider masterSldr, effectsSldr; // Sliders para controlar el volumen

    private void Start()
    {
        // Valores minimo y maximos de los osnidos y musica
        masterSldr.minValue = -80;
        masterSldr.maxValue = 10;

        effectsSldr.minValue = -80;
        effectsSldr.maxValue = 10;

        masterSldr.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        effectsSldr.value = PlayerPrefs.GetFloat("SFXVolume", 0f);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void MasterVolume()
    {
        DataManager.instancia.MusicData(masterSldr.value);
        musicMixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void EffectsVolume()
    {
        DataManager.instancia.SfxData(effectsSldr.value);
        effectsMixer.SetFloat("effectsVolume", PlayerPrefs.GetFloat("SFXVolume"));
    }

    public void PlayAudio(AudioSource audio) //Metodo para ejecutar un audio
    {
        audio.Play();
    }

    public void PararAudio()
    {
        mainMenuMusic.Stop();
        tormenta.Stop();
    }

    public void PararTodoAudio() //Paramos todos los posibles audios
    {
        mainMenuMusic.Stop();
        tormenta.Stop();
        musicMapa1.Stop();
        musicMapaCave.Stop();
        musicMapa2.Stop();
        musicMapa3.Stop();
        
        
    }
    public void paraMusicaPuzzle()
    {
        musicPuzzle.Stop();
    }

    public void Sword()
    {
        impact.Play();
    }

    public void Rama()
    {
        ramaImpact.Play();
    }
}
