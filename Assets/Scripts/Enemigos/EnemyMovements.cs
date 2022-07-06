using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    float speed;
    Rigidbody2D rb;
    Animator _anim;

    public bool isStatic;
    public bool isWalker;
    public bool isPatrol;
    public bool walksRight;

    public Transform wallCheck, pitCheck, groundCheck;
    private bool wallDetected, pitDetected, isGround;
    public float detectionRadius;
    public LayerMask whatIsGround;

    public Transform pointA, pointB;
    public bool goToA, goToB;


    private void Start()
    {
        goToA = true;
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Si la posicion del pitcheck  en el radio que nosotros determinamos que no esta detectando el suelo, marcamos falso
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);

        if (pitDetected || wallDetected)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (isStatic)
        {

            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (isWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (!walksRight)
            {
                _anim.SetBool("Caminar", true);
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);

            }
            else
            {
                _anim.SetBool("Caminar", true);
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
        if (isPatrol)
        {
            _anim.SetBool("Caminar", true);
            if (goToA)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                if(Vector2.Distance(transform.position, pointA.position)< 0.5f)
                {
                    Debug.Log("izquierda");
                    goToA = false;
                    goToB = true;
                }
            }

            if (goToB)
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                if (Vector2.Distance(transform.position, pointB.position) < 0.2f)
                {
                    Debug.Log("Derecha");
                    goToA = true;
                    goToB = false;
                }
            }
        }
    }

    public void Flip()
    {
        //Si esta caminando hacia un lado dejara de hacerlo
        walksRight = !walksRight;
        //Cambiamos la escala para que se gire
        transform.localScale *= new Vector2(-1f, 1f);
    }
}
