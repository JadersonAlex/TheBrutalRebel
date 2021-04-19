using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public static Health instance;

    public int health;
    public int heartsCount;


    public Image[] hearts;
    public Sprite fullheart; // coração completo 
    public Sprite emptyHeart; // coração vazio

   
    
    void Update()
    {
        for(int i = 0; i< hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < heartsCount)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
