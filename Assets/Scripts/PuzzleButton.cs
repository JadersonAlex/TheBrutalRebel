using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{

    private Animator anim;
    public Animator BarrierAnim;
    public LayerMask layer;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }


    // Quando estiver em cima do botão
    void Onpressed() 
    {
        anim.SetBool("isPressed", true);
        BarrierAnim.SetBool("isPressed", true);
        // colocar um audio pra tocar
       
    }

    // Quando sair de cima do botão
    void OnExit()
    {
        anim.SetBool("isPressed", false);
        BarrierAnim.SetBool("isPressed", false);
        // colocar um audio pra tocar]
       
    }

    //// Enquanto estiver tendo colisão
    //private void OnCollisionStay2D(Collision2D collision)
    //{

    //    if(collision.gameObject.CompareTag("box"))
    //    {
    //        Onpressed();
    //    }
    //}

    //// Quando o objeto sai da colisão
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("box"))
    //    {
    //        OnExit();
    //    }
    //}

    private void FixedUpdate()
    {
        OnCollision();
    }

    void OnCollision()
    {
        // 0.5f é o tamanho do colisor
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.5f, layer);

        if (hit != null)
        {
            Onpressed();
            hit = null;
        }
        else
        {
            OnExit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.5f); // 0.5f é o tamanho do Gizmos
    }
}
