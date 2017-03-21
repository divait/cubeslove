using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1.0f;
	private Transform pivot;

	private float initDistance;

	// Use this for initialization
	void Start () {
		pivot = transform.FindChild ("Pivot");

	}
	
	// Update is called once per frame
	void Update () {
		// Move front
		Vector3 destination = transform.position + transform.forward;
		transform.position = Vector3.Lerp (transform.position, destination, speed * Time.deltaTime);

		Debug.DrawLine (pivot.position, pivot.position - pivot.up, Color.yellow);
		Debug.DrawLine (pivot.position, pivot.position + pivot.forward, Color.gray);
		RaycastHit hit;

		// Rotation front Up
		if (Physics.Raycast (pivot.position, pivot.forward, out hit, 1.0f, 1 << LayerMask.NameToLayer ("Cubes")) && hit.distance < .35f) {
			Quaternion q = Quaternion.FromToRotation (transform.up, hit.normal);
			q = q * transform.rotation;

			transform.rotation = Quaternion.Slerp (transform.rotation, q, .05f);

			Debug.DrawLine (pivot.position, hit.point, Color.black);
		} else {
			// Rotation front Down
			if (Physics.Raycast (pivot.position, -pivot.up, out hit, 1.0f, 1 << LayerMask.NameToLayer ("Cubes"))) {

				Quaternion q = Quaternion.FromToRotation (transform.up, hit.normal);
				q = q * transform.rotation;

				transform.rotation = Quaternion.Slerp (transform.rotation, q, .08f);

				Debug.DrawLine (pivot.position, hit.point, Color.red);
			}
		}
			
		// Correction
		if (Physics.Raycast (transform.position, -transform.up + (-transform.forward/50), out hit, 1.0f, 1 << LayerMask.NameToLayer ("Cubes"))) {

			if (initDistance == 0)
				initDistance = Vector3.Distance (transform.position, hit.point);

			transform.position = (transform.position - hit.point).normalized * initDistance + hit.point;
		}
	}
}
