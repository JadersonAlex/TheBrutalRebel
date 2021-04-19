using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLvl : MonoBehaviour
{
    public string level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10) // 10 é o player)
        {
            SceneManager.LoadScene(level);
        }
    }
}
