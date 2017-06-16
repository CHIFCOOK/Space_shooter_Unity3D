using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RandomRotate : MonoBehaviour {
	public float tumble;
	public void Start(){
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
