using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_u_l_l_e_t : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
