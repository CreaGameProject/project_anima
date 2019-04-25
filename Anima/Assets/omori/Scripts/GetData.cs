using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetData : MonoBehaviour
{
    private Data data;


    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("GameManager").GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        int a;
        a=data.weapon.
    }
}
