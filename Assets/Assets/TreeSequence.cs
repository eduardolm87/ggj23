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
    Vector3 originalPosition;

    List<Transform> _transforms = new List<Transform>();

    public Transform _target = null;

    public float MoveSpeed = 1f;

    void Awake()
    {
        originalPosition = TreeCamera.transform.position;
       TreeScenario.SetActive(false);
        _transforms = TreeScenario.GetComponentsInChildren<Transform>().ToList();
    }

    public void TreeSequenceStart(string zNode) 
    {    
        TreeScenario.SetActive(true);
        UIObjects.ForEach(x=>{
            x.SetActive(false);
        });
        

       _target = _transforms.FirstOrDefault(x=>x.name == zNode);      
        Invoke("TreeSequenceEnd",5f);
  
    }


    public void ResetCamera()
    {
        _target = null;
    }

    void Update()
    {
        if(_target==null) return;

        TreeCamera.transform.position = Vector3.Lerp(TreeCamera.transform.position,_target.position,Time.deltaTime*MoveSpeed);        
    }

    


    void TreeSequenceEnd()
    {
        UIObjects.ForEach(x=>{
            x.SetActive(true);
        });
        TreeScenario.SetActive(false);
        _target = null;
        ResetCamera();
        Sequencer.Message("TreeSeqDone");
    }

    IEnumerator Timer(float seconds) 
    {
        yield return new WaitForSeconds(seconds);
        TreeSequenceEnd();
    }
    
}
