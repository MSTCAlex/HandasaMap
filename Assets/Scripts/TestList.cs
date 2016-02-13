using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TestList : MonoBehaviour {
	private GameObject Parent;
	private bool Visited = false;
	public List<GameObject> Neighbors = new List<GameObject> ();
	// Use this for initialization
	void Start () {
		Parent = this.gameObject;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public class Result{
		public List<GameObject> Parents {
			get;
			set;
		}

		public bool isFound {
			get;
			set;
		}
		public Result ()
		{
			Parents = new List<GameObject>();
		}
		public Result (bool isFound) : this()
		{
			this.isFound = isFound;
		} 
	}
	public Result Find (GameObject go, GameObject Caller){
		Result R;
		if (!this.Visited) {
			Visited = true;
			if (Parent == go) {
				R = new Result (true);
				R.Parents.Add (Parent);
				return R;
			} else {
				foreach (var item in Neighbors) {
					if (item != Caller) {
						R =  item.GetComponent<TestList>().Find(go, Parent);
						if (R.isFound) {
							R.Parents.Add (Parent);
							return R;
						}
					}
					continue;
				}

			}
		}
		R = new Result (false);
		return R;
	}

}
