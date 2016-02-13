using UnityEngine;
using System.Collections;

public class Hello : MonoBehaviour
{
	public GameObject Begin;
	public GameObject Target;
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
		TestList l = Begin.GetComponent<TestList> ();
		TestList.Result R = l.Find (Target, Begin);
		if (R.isFound)
			foreach (var item in R.Parents) {
				Debug.Log (item.name);
			}
	}
}
