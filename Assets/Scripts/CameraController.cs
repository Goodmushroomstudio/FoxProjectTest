using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    GameObject focusObject;
	// Use this for initialization
	void Start () {
        focusObject = GameObject.Find("Player").transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, focusObject.transform.position.x, 0.1f), Mathf.Lerp(transform.position.y, focusObject.transform.position.y, 0.1f), -10);
	}
}
