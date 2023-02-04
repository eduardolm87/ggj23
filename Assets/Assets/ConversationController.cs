using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ConversationController : MonoBehaviour
{
    
    public PixelCrushers.DialogueSystem.DialogueSystemTrigger DialogueSystemTrigger;
    public Transform player;
    public Transform narrator;
    
    
    public void GoToConversation(string zConversation)
    {
        Debug.Log("Convo");
        //DialogueSystemTrigger.StartConversation(player,narrator,0);
        DialogueManager.StartConversation(zConversation);

    }
}
