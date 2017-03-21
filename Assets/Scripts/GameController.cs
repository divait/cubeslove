using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public CubeController[] cubes;

	private int size = 3;

	// Use this for initialization
	void Start () {
		cubes = transform.GetComponentsInChildren<CubeController> ();
		print (cubes.Length);
	}
	
	public bool checkNext(CubeController.Direction dir, Transform transform) {
		Vector3 destination = Vector3.zero;

		switch (dir) {
		case CubeController.Direction.Up:
			destination = transform.position + Vector3.up;
			break;
		case CubeController.Direction.Down:
			destination = transform.position + Vector3.down;
			break;
		case CubeController.Direction.Left:
			destination = transform.position + Vector3.left;
			break;
		case CubeController.Direction.Right:
			destination = transform.position + Vector3.right;
			break;
		case CubeController.Direction.Back:
			destination = transform.position + Vector3.back;
			break;
		case CubeController.Direction.Front:
			destination = transform.position + Vector3.forward;
			break;
		}

		print ((size / 2.0f) + " " + destination);
		return (destination.x <= size / 2.0f && destination.y <= size /  2.0f && destination.z <= size / 2.0f);
	}
}
