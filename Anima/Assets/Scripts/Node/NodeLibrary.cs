using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    DEATH, EXPLORING, VIGILANCE, SEARCH, DISCOVERED
}

public class NodeLibrary : MonoBehaviour
{
    private State libraryType;
    private List<Node> nodes = new List<Node>();
}
