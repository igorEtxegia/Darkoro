using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiaTeclas : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvas.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvas.SetActive(false);

        }
    }

}
