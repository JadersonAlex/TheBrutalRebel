using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public GameObject barreiraAmarela;
    public GameObject barreiraAmarela2;

    private Animator anim;
    private Rigidbody2D rig;
    public bool isFront;

    private Vector2 direction;
    private bool isDead;

    public bool isRight;
    public float stopDistance;

    public int health = 3; // vida
    public float speed;
    public float maxVision;
    public Transform point;
    public Transform behind; 


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (isRight) // se for verdade ele vira pra direita
        {
            transform.eulerAngles = new Vector2(0, 0);
            direction = Vector2.right;
           
        }
        else // senão vira pra esquerda
        {
            transform.eulerAngles = new Vector2(0, 180);
            direction = Vector2.left;
            
        }
    }

    

   

    void FixedUpdate()
    {
        GetPlayer();
        OnMove();
    }

    void OnMove()
    {
        if(isFront && !isDead)
        {
            anim.SetInteger("transition", 1); // animação de andar

            if (isRight) // se for verdade ele vira pra direita
            {
                transform.eulerAngles = new Vector2(0, 0);
                direction = Vector2.right;
                rig.velocity = new Vector2(speed, rig.velocity.y);
            }
            else // senão vira pra esquerda
            {
                transform.eulerAngles = new Vector2(0, 180);
                direction = Vector2.left;
                rig.velocity = new Vector2(-speed, rig.velocity.y);
            }


        }
       
    }


    void GetPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.position, direction, maxVision);

        if (hit.collider != null && !isDead)
        {
            if (hit.transform.CompareTag("Player"))
            {
                isFront = true;

                float distance = Vector2.Distance(transform.position, hit.transform.position);

                if(distance <= stopDistance)
                {
                    isFront = false;
                    rig.velocity = Vector2.zero;

                    anim.SetInteger("transition", 2); // animação de atacar

                    hit.transform.GetComponent<Player>().OnHit();
                }
            }
        }

       

        RaycastHit2D behindHit = Physics2D.Raycast(behind.position, -direction, maxVision);

        if(behindHit.collider != null)
        {
            if (behindHit.transform.CompareTag("Player"))
            {
                // player está nas coisas do inimigo
                isRight = !isRight;
                isFront = true;
            }
        }
    }


    public void OnHit()
    {
        anim.SetTrigger("hit");
        health--;

        if(health <= 0)
        {
            isDead = true;
            speed = 0;
            anim.SetTrigger("dead");
            Destroy(gameObject, 1f);
            barreiraAmarela.SetActive(false); // desativando a barreira amarela ao morrer
            barreiraAmarela2.SetActive(false); // desativando a barreira amarela ao morrer

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(point.position, direction * maxVision); // frente
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(behind.position, -direction * maxVision); // trás
    }
}
