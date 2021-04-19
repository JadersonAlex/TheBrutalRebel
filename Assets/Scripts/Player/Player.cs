using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAudio playerAudio;
    private Rigidbody2D rig;
    public Animator anim;
    public Transform point;
    public GameObject GameOver;
    public GameObject jogador;

    public LayerMask enemyLayer;

    public float radius;
    public float speed;
    public float jumpForce;
    

    public Health healthSystem;

    private bool recovery;
    private bool isJumping;
    private bool doubleJump;
    private bool isAttacking;



   // public int health; // vida do player



    // -- Mantendo o mesmo objeto do player ao passar de fase ----
    public static Player instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
   // ---------------------------------------------------------------




    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<PlayerAudio>();
        healthSystem = GetComponent<Health>();
    }

    void Update()
    {
        Jump();
        Attack();

        if(healthSystem.health == 0) // se a vida for igual a zero
        {
            GameOver.SetActive(true); // ativando o painel do GameOver
            jogador.SetActive(false); // desativando o jogador quando a vida chegar em zero
        }
    }

    void FixedUpdate()
    {
        Move();    
    }

    // ----------- movimento do personagem -----------------
    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if(movement > 0)
        {
            if(!isJumping && !isAttacking)
            {
                anim.SetInteger("transition", 1);
            }
           
            transform.eulerAngles = new Vector3(0, 0, 0); // vira pra direita
        }

        if(movement < 0)
        {
            if(!isJumping && !isAttacking)
            {
                anim.SetInteger("transition", 1);
            }
           
            transform.eulerAngles = new Vector3(0, 180, 0); // vira pra esquerda
        }

       if(movement == 0 && !isJumping && !isAttacking) 
        {
            anim.SetInteger("transition", 0);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                doubleJump = true;
                playerAudio.PlaySFX(playerAudio.jumpSound);
            }
            else if(doubleJump)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                doubleJump = false;
                playerAudio.PlaySFX(playerAudio.jumpSound);
            }
        }
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Z)) 
        {
            isAttacking = true;
            anim.SetInteger("transition", 3);

            Collider2D hit = Physics2D.OverlapCircle(point.position, radius, enemyLayer);
            playerAudio.PlaySFX(playerAudio.hitSound);
            if (hit != null)
            {   

                if (hit.GetComponent<Slime>())
                {
                    hit.GetComponent<Slime>().OnHit();
                }


                if (hit.GetComponent<SlimeBlue>())
                {
                    hit.GetComponent<SlimeBlue>().OnHit();
                }

                if (hit.GetComponent<Knight>())
                {
                    hit.GetComponent<Knight>().OnHit();
                }


            }
            StartCoroutine(OnAttack());
        }
        
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(0.5f); // tempo de cada ataque
        isAttacking = false;
    }

    float recoveryCount;
   public void OnHit()
    {
        recoveryCount += Time.deltaTime;

        if(recoveryCount >= 0.7f) // dano por segundo
        {
            anim.SetTrigger("hit");
            healthSystem.health--;
            recoveryCount = 0;
        }
        
        // -- obs: se bugar na hora que o player morrer basta remover o && !recovery e recovery = true --------
        if(healthSystem.health <= 0 && !recovery)
        {
             recovery = true;
             anim.SetTrigger("dead");
              
            //  Debug.Log("Game over!");
            GameController.instance.ShowGameOver(); // Chamando o gameover no script GameController
            // destruir o jogador ou desativa-lo quando ele morrer 
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(point.position, radius);    
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if(colisor.gameObject.layer == 8)
        {
            isJumping = false;
        }

        // --- Checando a colisão com o checkpoint --------
        if(colisor.gameObject.layer == 12) // 12 é a layer checkpoint
        {
            PlayerPos.instance.Checkpoint();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9) // layer 9 é a layer enemy 
        {
            OnHit();
        }

        if(collision.CompareTag("Coin"))
        {
            playerAudio.PlaySFX(playerAudio.coinSound);
            GameController.instance.GetCoin();
            Destroy(collision.gameObject);
        }
/*
        if(collision.gameObject.layer == 11) // 11 é a layer door
        {
            GameController.instance.NextLevel();
        }
*/
        //  fazendo o som tocar cao colidir com o player 
        if (collision.CompareTag("ButtonSFX"))
        {
            playerAudio.PlaySFX(playerAudio.buttonSound);     
        }
    }



 
}
