using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System;
using System.Linq;

public class TreeSequence : MonoBehaviour
{
    public GameObject TreeScenario;
    public GameObject TreeCamera;
    public List<GameObject> UIObjects = new List<GameObject>();

    List<Transform> _transforms = new List<Transform>();


    void Awake()
    {
       // TreeScenario.SetActive(false);
        _transforms = TreeScenario.GetComponentsInChildren<Transform>().ToList();
    }

    public void TreeSequenceStart(string zNode) 
    {
        TreeScenario.SetActive(true);
        UIObjects.ForEach(x=>{
            x.SetActive(false);
        });
        //Invoke("TreeSequenceEnd",0.1f);

        var target = _transforms.FirstOrDefault(x=>x.name == zNode);
        Debug.Log("me voy a nodo "+target.name+" que esta en pos "+target.position);


    }

    


    void TreeSequenceEnd()
    {
        UIObjects.ForEach(x=>{
            x.SetActive(true);
        });
        TreeScenario.SetActive(false);
        Sequencer.Message("TreeSeqDone");
    }

    IEnumerator Timer(float seconds) 
    {
        yield return new WaitForSeconds(seconds);
        TreeSequenceEnd();
    }
    
}
