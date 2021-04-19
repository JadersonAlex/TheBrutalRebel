using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruindoobj : MonoBehaviour
{
    // este script destrói todos os objetos com uma determinada tag 



    public void Update()
    {
        
        DestroyAllObjects();
        DestruaTodosOsObj();
    }

    // destruindo o canvas
    public void DestroyAllObjects()
    {
        // Coleta os objetos
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("canvas");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            // Destrói o item em si
            Destroy(gameObjects[i]);
        }
    }


    // destruindo o canvas
    public void DestruaTodosOsObj()
    {
        // Coleta os objetos
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            // Destrói o item em si
            Destroy(gameObjects[i]);
        }
    }

}
