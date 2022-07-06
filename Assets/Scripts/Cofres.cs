using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofres : MonoBehaviour
{
    private Animator _anim;
    public GameObject chestItem;
    public float chestDelay;
    private bool itemPicked = false;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !itemPicked)
            {
                _anim.Play("AM Chest Iron - Open");
                StartCoroutine(GetChestItem());
            }
        }
    }

    IEnumerator GetChestItem()
    {
        yield return new WaitForSeconds(chestDelay);
        Instantiate(chestItem, transform.position, Quaternion.identity);
        itemPicked = true;
    }
}
