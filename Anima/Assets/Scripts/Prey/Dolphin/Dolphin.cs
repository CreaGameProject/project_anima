using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolphin : PreyStatus
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void LibrariesInitialize()
    {
        throw new System.NotImplementedException();
    }

    protected override void StatusInitialize()
    {
        base.StatusInitialize();
    }

    public override int Vision()
    {
        throw new System.NotImplementedException();
    }

    public override int Hearing()
    {
        throw new System.NotImplementedException();
    }

    public override int Olfaction()
    {
        throw new System.NotImplementedException();
    }
}
