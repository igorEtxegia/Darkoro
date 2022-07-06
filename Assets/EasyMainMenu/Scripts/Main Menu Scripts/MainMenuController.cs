using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    Animator anim;

    public string SampleScene;
    public int quickSaveSlotID;

    [Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public GameObject StartGameOptionsPanel;
    public GameObject GamePanel;
    public GameObject ControlsPanel;
    public GameObject LoadGamePanel;
    public GameObject IdiomasPanel;
    public GameObject objeto;
    public GameObject objeto2;
    public GameObject objeto3;

    // Use this for initialization
    void Start () {
        
        anim = GetComponent<Animator>();
        //new key
        PlayerPrefs.SetInt("quickSaveSlot", quickSaveSlotID);
       
    }

    #region Open Different panels

    public void openOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(true);
        StartGameOptionsPanel.SetActive(false);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");
       
    }

    public void openStartGameOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(true);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");
        
    }

    public void openOptions_Game()
    {
        //enable respective panel
        GamePanel.SetActive(true);
        IdiomasPanel.SetActive(false);
        ControlsPanel.SetActive(false);
        LoadGamePanel.SetActive(false);
        

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }

    public void openIdiomas()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        IdiomasPanel.SetActive(true);
        ControlsPanel.SetActive(false);
        LoadGamePanel.SetActive(false);
        


        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }

    public void openOptions_Controls()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        IdiomasPanel.SetActive(false);
        ControlsPanel.SetActive(true);
        LoadGamePanel.SetActive(false);
        

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }

    public void openContinue_Load()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        LoadGamePanel.SetActive(true);
        IdiomasPanel.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }




    public void newGame()
    {
        DontDestroyOnLoad(objeto);
        SceneManager.LoadScene(1);
        
    }

    public void Mapa2()
    {

        DontDestroyOnLoad(objeto);
        SceneManager.LoadScene(1);
    }

 
    public void Mapa3()
    {
        DontDestroyOnLoad(objeto);     
        SceneManager.LoadScene(1);
    }

    public void MapaPuzzle()
    {
        DontDestroyOnLoad(objeto);
        SceneManager.LoadScene(1);
    }


    #endregion

    #region Back Buttons

    public void back_options()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("buttonTweenAnims_off");

        //disable BLUR
       // Camera.main.GetComponent<Animator>().Play("BlurOff");

        //play click sfx
        playClickSound();
    }

    public void back_options_panels()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("OptTweenAnim_off");
        
        //play click sfx
        playClickSound();

    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Sounds
    public void playHoverClip()
    {
       
    }

    void playClickSound() {

    }


    #endregion
}
