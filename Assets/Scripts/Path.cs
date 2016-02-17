using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class Path
{
    public Stack<GameObject> Nodes
    {
        get;
        set;
    }
    public bool IsFound
    {
        get;
        set;
    }
    public Path(bool isFound = false)
    {
        Nodes = new Stack<GameObject>();
        IsFound = isFound;
    }

    internal void Add(GameObject node)
    {
        Nodes.Push(node);
    }
}
