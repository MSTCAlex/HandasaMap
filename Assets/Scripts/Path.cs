using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class Path
{
    public List<GameObject> Nodes
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
        Nodes = new List<GameObject>();
        this.IsFound = isFound;
    }
}
