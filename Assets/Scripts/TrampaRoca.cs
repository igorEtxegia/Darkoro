using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaRoca : MonoBehaviour
{
    private Animator _animator;
    public GameObject _roca;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.SetBool("Romper", true);
        StartCoroutine(DesaparecerRoca());
        
        
    }

    IEnumerator DesaparecerRoca()
    {
        yield return new WaitForSeconds(2);
        _roca.SetActive(false);
    }
}
