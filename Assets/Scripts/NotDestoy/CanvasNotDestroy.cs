using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasNotDestroy : MonoBehaviour
{
    // -- Mantendo o mesmo objeto  ao passar de fase ----
    private static CanvasNotDestroy instance;

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
