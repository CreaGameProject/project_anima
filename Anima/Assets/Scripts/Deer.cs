using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : DecisionMaker
{
    protected override IEnumerator FindState()
    {
        while (true)
        {
            yield return null;
        }
    }
}
