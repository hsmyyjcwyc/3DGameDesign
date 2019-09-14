using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBeh : MonoBehaviour {

	public Transform res;

	// Use this for initialization
	void Start () {
		// Load Resources
		GameObject newobj = Instantiate<Transform> (res, this.transform).gameObject;
		newobj.transform.position = new Vector3 (0, Random.Range (-5, 5), 0);
	}
}