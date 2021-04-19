using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllNotDestroy : MonoBehaviour


{     // -- Mantendo o mesmo objeto ao passar de fase ----
    private static GameControllNotDestroy instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
