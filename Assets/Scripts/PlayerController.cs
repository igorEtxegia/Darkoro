using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instancia;

    public Transform groundcheck1;
    public Transform groundcheck2;
    public GameObject check;
    public GameObject palo;
    public GameObject primeraEspada;
    public CameraShake cameraShake;
    
    public LayerMask WhatIsGround;
    
    public bool isGrounded;

    public float groundCheckRadius;
    public float speed, jumpHeight;
    
    private BoxCollider2D _colision;
    private Rigidbody2D _rigibody;
    private Rigidbody2D rb;
    private Animator _animator;

    private float velX, velY;

    [Header("Layer")]
    public LayerMask ladderMask;
    public float vertical;
    public float climbSpeed = 3;
    public float checkRadius = 0.3f;
    public bool climbing;
    public int dmg = 1;

    void Awake()
    {
        instancia = this;
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        //Recuperamos el componente de colision -------
        _colision = GetComponent<BoxCollider2D>();
        //Recuperamos el componente de fisicas
        _rigibody = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundcheck1.position, groundCheckRadius, WhatIsGround) || Physics2D.OverlapCircle(groundcheck2.position, groundCheckRadius, WhatIsGround);
        FlipCharacter();
        Attack();

    }

    //Metodo para bloquear al personaje cuando salgan las ventanas de dialogos
    public void PararPersonaje(bool pararPJ)
    {
        //Cuando salga en dialogo hacemos que nuestro personaje no pueda moverse
        if(pararPJ == true)
        {
            _animator.enabled = false;
            speed = 0f;
            jumpHeight = 0f;
        }
        else //Cuando salga en dialogo hacemos que nuestro personaje pueda volver a moverse
        {
            _animator.enabled = true;
            speed = 10f;
            jumpHeight = 20f;
        }   
    }

    //Metodo para el salto
    public void Jump()
    {
        //Si se presiona el boton de salto y esta tocando suelo aplicamos la fuerza de salto
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    private void FixedUpdate()
    {
        Movement();
        ClimbLadder();
        Jump();
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (primeraEspada.activeSelf == true && _animator.enabled == true)
            {
                AudioManager.instance.Sword();
            }
            else if(palo.activeSelf == true && _animator.enabled == true)
            {
                AudioManager.instance.Rama();
            }
            _animator.SetTrigger("Attack");
        }
    }



    public void Movement()
    {
        vertical = Input.GetAxis("Vertical");
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);
    }

    //Metodo para girar el sprite del personaje
    public void FlipCharacter()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _animator.SetBool("Run", true);
        }
        
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _animator.SetBool("Run", true);
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
           
            _animator.SetBool("Run", false);
        }

    }


    //Corrutina que se ejecuta cuando el jugador muere
    public IEnumerator MuerteJugador()
    {
        Debug.Log("El jugador se ha echo daño");
        //Deshabilitamos el script
        enabled = false;
        //Quitamos toda la velocidad
        _rigibody.velocity = Vector2.zero;
        _animator.SetBool("Run", false);
        _animator.SetBool("Die",true);

        TroncoCascada.instancia.TroncoOff();
       // _rigibody.gravityScale = 0;
    
        
        yield return new WaitForSeconds(2);
        
        //Lanzamos la corrutina de muerte del jugador en el GameManager
        StartCoroutine(GameManager.instancia.OnJugadorMuerto());

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformaMovible")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Placa")
        {
            StartCoroutine(cameraShake.shake());
            collision.gameObject.SetActive(false);
        }
    }

    bool TouchingLadder()
    {
        return _colision.IsTouchingLayers(ladderMask);
    }

    void ClimbLadder()
    {

        bool up = Physics2D.OverlapCircle(transform.position, checkRadius, ladderMask);
        bool  down = Physics2D.OverlapCircle(transform.position + new Vector3(0, -1), checkRadius, ladderMask);

        if (vertical !=0 && TouchingLadder())
        {
            climbing = true;
            rb.isKinematic = true;
        }

        if (climbing)
        {

            if(!up && vertical >= 0)
            {
                FinishClimb();
                return;
            }

            if (!down && vertical <= 0)
            {
                FinishClimb();
                return;
            }

            float y = vertical * climbSpeed;
            rb.velocity = new Vector2(0, y);
        }
    }

    void FinishClimb()
    {
        climbing = false;
        rb.isKinematic = false;
    }


    //Si nos salimos de la plataforma dejamos de ser su hijo
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformaMovible")
        {
            //Llamamos al metodo Emparentar pasandole el transform del persoanje
            GameManager.instancia.Emparentar(transform);
        }
    }


    public void CambioDeArma()
    {
        palo.SetActive(false);
        primeraEspada.SetActive(true);
        CambioDMG();
    }

    public void CambioDMG()
    {
        dmg = 2;
    }
    
}
