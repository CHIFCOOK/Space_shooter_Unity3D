using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMover : MonoBehaviour {

	public float speed;

	private Vector3 refresh =  new Vector3 (0f, 0f, 0f);

	void Update () {
		Transform tf = GetComponent<Transform> ();

		tf.Translate (Vector3.back * Time.deltaTime * speed);

		if (tf.position.z < -30f) {
			tf.position = refresh;
		}
	}
}