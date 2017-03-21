using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform center;
	public float speed = 1.0f;

	private Vector3 distanceCenter;
	private Vector3 nextDistanceCenter;
	private float mouseX;
	private float mouseY;

	// Use this for initialization
	void Start () {
		distanceCenter = transform.position - center.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Move Camera on mouse clicked
		if (Input.GetMouseButton (1)) {
			mouseX += Input.GetAxis ("Mouse X");
			mouseY -= Input.GetAxis ("Mouse Y");

			transform.RotateAround (Vector3.zero, center.transform.up, mouseX * speed * Time.deltaTime);
			transform.RotateAround (Vector3.zero, center.transform.right, mouseY * speed * Time.deltaTime);

			center.transform.rotation = transform.rotation;
		}

		if (Input.GetMouseButtonUp (1)) {
			mouseX = 0;
			mouseY = 0;
		}

		// Show Controls
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 200, 1 << LayerMask.NameToLayer ("Cubes"))) {
			Debug.DrawLine (ray.origin, hit.point, Color.green);

			hit.transform.GetComponent<CubeController> ().showControllHitFace(hit);
		}
	}
}
