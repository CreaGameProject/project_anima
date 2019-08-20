using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator ac;

    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<Animator>();
    }

    public void WalkAnimation(bool walk){
        ac.SetBool("Walking", walk);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
