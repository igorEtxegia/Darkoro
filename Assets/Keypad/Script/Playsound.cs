using UnityEngine;
using System.Collections;
using TMPro;

public class Playsound : MonoBehaviour 
{
	public TextMeshProUGUI numero;
	public TextMeshProUGUI pantalla;
	public GameObject panel;
	public GameObject puerta;
	public float dmgPanelError = 1f;
	public FinNivel3 finNivel3;
	private string prueba;

	public void Clicky (){
		GetComponent<AudioSource>().Play();
	}


    private void OnEnable()
    {
		numero = GetComponentInChildren<TextMeshProUGUI>();
		
	}

    public void CambiarPantalla (){
        if (pantalla.text.Length <=2)
        {
			
			pantalla.text = pantalla.text + numero.text;
			
        }
		
	}

	public void ComprobarNumero()
	{

		if (pantalla.GetComponent<TextMeshProUGUI>().text == "825")
        {
			finNivel3.CerrarPanel();
			puerta.SetActive(false);
        }
        else
        {
			PlayerStats.Instance.TakeDamage(dmgPanelError);
		}
	}

	public void BorrarNumero()
    {
		if(pantalla.text.Length == 0)
        {
			pantalla.text = "";
        }
        else
        {
			prueba = pantalla.GetComponent<TextMeshProUGUI>().text;
			prueba = prueba.Remove(prueba.Length - 1);
			//Debug.Log(prueba);
			pantalla.text = prueba;
		}
		
	}

	public void Cerrar()
    {
		finNivel3.CerrarPanel();
	}

}
