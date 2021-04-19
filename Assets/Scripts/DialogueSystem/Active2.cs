using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active2 : MonoBehaviour
{
    public GameObject barreiraAmarela;
    public GameObject barreiraAmarela2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        barreiraAmarela.SetActive(true);
        barreiraAmarela2.SetActive(true);
    }
}
