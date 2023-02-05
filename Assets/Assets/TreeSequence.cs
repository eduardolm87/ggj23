using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System;
using System.Linq;

public class TreeSequence : MonoBehaviour
{
    public GameObject TreeScenario;
    public GameObject PlayerPivot;    
    public List<GameObject> UIObjects = new List<GameObject>();

    List<Transform> _transforms = new List<Transform>();


    void Awake()
    {
        TreeScenario.SetActive(false);
        _transforms = TreeScenario.GetComponentsInChildren<Transform>().ToList();
        Debug.Log("tengo "+_transforms.Count+" hijos");
    }

    public void TreeSequenceStart() 
    {
        TreeScenario.SetActive(true);
        UIObjects.ForEach(x=>{
            x.SetActive(false);
        });
        Invoke("TreeSequenceEnd",0.1f);
    }

    IEnumerator Timer(float seconds) 
    {
        yield return new WaitForSeconds(seconds);
        TreeSequenceEnd();
    }


    void TreeSequenceEnd()
    {
        UIObjects.ForEach(x=>{
            x.SetActive(true);
        });
        TreeScenario.SetActive(false);
        Sequencer.Message("TreeSeqDone");
    }
    
}
