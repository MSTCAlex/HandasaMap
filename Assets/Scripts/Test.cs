using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
	public PathNode Begin;
	public PathNode Target;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	public void Hi()
	{
		PathNode l = Begin.GetComponent<PathNode> ();
		Path P = l.Find (Target.ID, Begin.ID);
		if (P.IsFound)
			foreach (var item in P.Nodes) {
				Debug.Log (item.name);
			}
	}
}
