using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PerceptionLevel
{
    Undiscovered, Recognition, Discovered
}

/// <summary> 穢物の知覚モジュール </summary>
public class Perception : MonoBehaviour
{
    
    
    public delegate IEnumerator PerceptionEvent(Vector3 position);

    public PerceptionLevel perceptionLevel = PerceptionLevel.Undiscovered;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
