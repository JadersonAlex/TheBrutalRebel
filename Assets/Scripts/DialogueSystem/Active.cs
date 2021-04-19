using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public GameObject btn_balao;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        btn_balao.SetActive(true);
    }

}
