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
		//transform.RotateAround (center.position, Input.GetAxis ("Mouse X") * speed * Time.deltaTime);


		if (Input.GetMouseButton (1)) {
			mouseX += Input.GetAxis ("Mouse X");
			mouseY -= Input.GetAxis ("Mouse Y");

			print ("Data x: "+ mouseX + ", y: "+ mouseY);

			transform.RotateAround (Vector3.zero, center.transform.TransformDirection(Vector3.up), mouseX * speed * Time.deltaTime);
			transform.RotateAround (Vector3.zero, center.transform.TransformDirection(Vector3.right), mouseY * speed * Time.deltaTime);

			center.transform.rotation = transform.rotation;
		}

		if (Input.GetMouseButtonUp (1)) {
			mouseX = 0;
			mouseY = 0;
		}
	}
}
