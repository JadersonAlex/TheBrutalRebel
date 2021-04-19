using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsAnim : MonoBehaviour
{

     // este script está no obj btn_options 


    public Animator anim; // animator do opções
    


    private GameObject options;
    


    private void Start()
    {
        options = GameObject.FindGameObjectWithTag("options");
       
    }
    public void select()
    {
        anim.SetTrigger("select");
    }

    public void back()
    {
        anim.SetTrigger("return");
    }

    

    public void Op1()
    {

        if (options != null)
        {
            anim.SetTrigger("select");
        }
    }


    public void Op2()
    {

        if (options != null)
        {
            anim.SetTrigger("return");
        }
    }
}
