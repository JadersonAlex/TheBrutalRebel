using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    
    public int value;
    public string Name;

    public GameObject objPrefab;

    private Player player;


    public GameObject Painel_No_Money;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
        
    }

    public void BuyItem1()
    {
        if (GameController.instance.score >= value) 
        {
            GameController.instance.score -= value; // descontando o valor
            Player.instance.healthSystem.health++; // adicionando 1 de vida
        }
        else
        {
            // Não tem dinheiro
            Painel_No_Money.SetActive(true);
            
        }
    }


    public void BuyItem2()
    {
        if (GameController.instance.score >= value)
        {
            GameController.instance.score -= value; // descontando o valor
            Player.instance.healthSystem.health = +2; // adicionando 2 de vida

        }
        else
        {
            // Não tem dinheiro
            Painel_No_Money.SetActive(true);
        }
    }


    public void BuyItem3()
    {
        if (GameController.instance.score >= value)
        {
            GameController.instance.score -= value; // descontando o valor
            Player.instance.healthSystem.health = +3; // adicionando 3 de vida
        }
        else
        {
            // Não tem dinheiro
            Painel_No_Money.SetActive(true);
        }
    }
}
