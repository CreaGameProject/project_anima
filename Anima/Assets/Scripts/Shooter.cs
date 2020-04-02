using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Prey;
using UnityEngine;
using UnityEngine.AI;
using UnityEngineInternal.Input;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform prey;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var origin = transform.position;
            var direction = (prey.position - origin).normalized;
            Debug.Log(Physics.Raycast(transform.position, direction, out RaycastHit hit));
            Debug.DrawRay(origin, direction * 10000, Color.cyan);
            Debug.Log(hit.collider != null ? hit.collider.name : "null");
        }

    }

    void Start()
    {
        prey.GetComponent<Prey>().MoveStart(transform.position, 1f);
    }
}
