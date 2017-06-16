using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestoryByTime : MonoBehaviour {
	public float timer = 2;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, timer);
	}

}
