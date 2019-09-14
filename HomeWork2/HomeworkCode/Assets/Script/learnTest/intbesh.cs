using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class intbesh : MonoBehaviour {
 
    // Use this for initialization
 
    private void Awake()
    {
        Debug.Log("awake!");
    }
 
    void Start () {
        Debug.Log("start!");
	}
	
	// Update is called once per frame
    void Update () {
        Debug.Log("update!");
	}
 
    private void FixedUpdate()
    {
        Debug.Log("fixedupdate!");
    }
 
    private void OnGUI()
    {
        Debug.Log("ONGUI!");
    }
 
    private void OnDisable()
    {
        Debug.Log("OnDisable!");
    }
 
    private void OnEnable()
    {
        Debug.Log("OnEnable!");
    }
}