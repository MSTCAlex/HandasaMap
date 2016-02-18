using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PathNode : MonoBehaviour
{
    private static int LastTarget = -1;
    // Those maps ensure that a node, its name and its ID are findable in O(1) given any of them
    // Another approach is to hash the names but then we won't have direct control of the IDs anymore
    public static Dictionary<uint, PathNode> IDNodeMap = new Dictionary<uint, PathNode>();
    public static Dictionary<string, uint> NameIDMap = new Dictionary<string, uint>();
    /// <summary>
    /// Finds the shortest path, if any, between 2 nodes given their names.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static Path Find(string start, string target)
    {
        return Find(IDNodeMap[NameIDMap[start]], NameIDMap[target]);
    }
    /// <summary>
    /// Finds the shortest path, if any, between 2 nodes given the start node and the target node ID.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="targetid"></param>
    /// <returns></returns>
    public static Path Find(PathNode start, uint targetid)
    {
        if (targetid != LastTarget)
            foreach (PathNode node in IDNodeMap.Values)
                node.Visited = false;
        return start.Find(targetid);
    }
    public uint ID;
    public List<GameObject> Neighbors = new List<GameObject>();
    private bool Visited = false;
	Path mostrecentpath = new Path();
    // Use this for initialization, the constructor behaves unexpectedly
    void Awake() // Awake is guaranteed to precede Start() anywhere in the project
    {
#if DEBUG // Warn the designer of duplicate IDs
        if (IDNodeMap.ContainsKey(ID))
            throw new System.Exception("Designer Error Detected: \"" + name + "\" & \"" + IDNodeMap[ID].name + "\" both have ID=" + ID);
#endif
        NameIDMap[name] = ID;
        IDNodeMap[ID] = this;
    }
    public GameObject Owner { get { return gameObject; } }
    private Path Find(uint target)
    {
        Path current = new Path();
        if (ID == target) // Need to ensure that a new path instance is created for every visit to the target
        {
            current.IsFound = true;
            current.Add(Owner);
            return current;
        }
        else if (!Visited)
        {
            Visited = true;
            current = new Path();
            int minlen = int.MaxValue;
            foreach (var item in Neighbors.Select(i => i.GetComponent<PathNode>()))
            {
                Path P = item.Find(target);
                if (P.IsFound && P.Nodes.Count <= minlen)
                {
                    // We can later process all equal length paths here as forks instead of choosing first/last one                            
                    minlen = P.Nodes.Count; // Zero based
                    P.Add(Owner);
                    current = P;
                }
            }
            mostrecentpath = current;
        }
        return mostrecentpath;
    }

}
