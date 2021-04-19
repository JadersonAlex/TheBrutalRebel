using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierLife : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    private Animator anim;

    public int health; // vida do slime

    public Transform point;
    public float radius;
    public LayerMask layer;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
        OnCollision();
    }

    void OnCollision()
    {
        Collider2D hit = Physics2D.OverlapCircle(point.position, radius, layer);

        if (hit != null)
        {
            // só é chamado quando o inimigo bate em um objeto que tenha a layer selecionada
            //Debug.Log("Bateu!");

            speed = -speed; // inverte o valor da variável  

            if (transform.eulerAngles.y == 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    public void OnHit()
    {
        anim.SetTrigger("hit");
        health--;

        if (health <= 0)
        {
            speed = 0;
            anim.SetTrigger("dead");
            Destroy(gameObject, 1f);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(point.position, radius);
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {


            anim.SetTrigger("Atk");


            collision.gameObject.transform.Translate(-Vector2.right * 0.10f); // Jogando o jogador  para trás ao colidir
            Player.instance.healthSystem.health--; // removendo uma vida



        }

    }
   */

}

