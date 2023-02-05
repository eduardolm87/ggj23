using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System;
using System.Linq;

public class TreeSequence : MonoBehaviour
{
    public GameObject TreeScenario;


    void Awake()
    {
        TreeScenario.SetActive(false);
    }

    public void TreeSequenceStart(string zNodeName) {
        
        TreeScenario.SetActive(true);
    }


    void TreeSequenceEnd()
    {
        Sequencer.Message("TreeSeqDone");
    }
    
}
