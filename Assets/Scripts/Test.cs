using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    public PathNode Begin;
    public PathNode Target;
    // Use this for initialization
    void Start()
    {
        //PathNode l = Begin.GetComponent<PathNode>();
       
    }

	public void Search()
	{
		Path P = PathNode.Find(Begin, Target.ID);
		if (P.IsFound)
			foreach (var item in P.Nodes)
			{
				Debug.Log(item.name);
			}
	}

    // Update is called once per frame
    void Update()
    {

    }    
}
