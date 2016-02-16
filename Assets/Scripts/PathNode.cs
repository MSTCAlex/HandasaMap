using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PathNode : MonoBehaviour
{
    public static List<PathNode> AllNodes = new List<PathNode>();
    public int ID;
    public List<GameObject> Neighbors = new List<GameObject>();    
    private bool Visited = false;
    Path mostrecntresult;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public PathNode()
    { AllNodes.Add(this); }
    public GameObject Owner { get { return gameObject; } }
    public Path Find(int target, int start)
    {
        if (!Visited)
        {
            Visited = true;
            mostrecntresult = new Path();
            if (ID == target)
            {
                mostrecntresult = new Path(true);
                mostrecntresult.Nodes.Add(Owner);
                return mostrecntresult;
            }
            else
            {
                int minlen = int.MaxValue;
                foreach (var item in Neighbors.Select(i => i.GetComponent<PathNode>()))
                {
                    if (item.ID != start)
                    {
                        Path P = item.Find(target, ID);
                        if (P.IsFound && P.Nodes.Count <= minlen)
                        {
                            // We can later process all equal length paths here as forks instead of choosing first/last one                            
                            minlen = P.Nodes.Count; // Zero based
                            P.Nodes.Add(Owner);                            
                            mostrecntresult = P;                            
                        }
                    }
                }
            }
        }
        return mostrecntresult;
    }

}
