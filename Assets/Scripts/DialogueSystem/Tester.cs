using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Conversation convo;

    public static Tester instance;
    public void StartConvo()
    {
        DialogueManager.StartConversation(convo);
        
    }

    
}
