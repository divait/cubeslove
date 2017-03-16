using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	enum Direction {Up, Down, Left, Right, Front, Back};

	public float speed = 0.2f;
	public Vector3 initialPostion;

	private GameController gameController;
	private float startTime;
	private float journeyLength;
	private Vector3 destination;
	private bool isMoving;

	void Start() {
		isMoving = false;
		gameController = transform.parent.GetComponent<GameController> ();
	}

	void Update() {

		if (!isMoving) {
			if (Input.GetKeyDown (KeyCode.W)) { // Up
				startMove (Direction.Up);
			} else if (Input.GetKeyDown (KeyCode.S)) { // Down
				startMove (Direction.Down);
			} else if (Input.GetKeyDown (KeyCode.A)) { // Left
				startMove (Direction.Left);
			} else if (Input.GetKeyDown (KeyCode.D)) { // Right
				startMove (Direction.Right);
			} else if (Input.GetKeyDown (KeyCode.Q)) { // Back
				startMove (Direction.Back);
			} else if (Input.GetKeyDown (KeyCode.E)) { // Front
				startMove (Direction.Front);
			}
		} else {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;

			transform.position = Vector3.Lerp(transform.position, destination, fracJourney);

			if (transform.position == destination)
				isMoving = false;
		}
	}


	void startMove (Direction dir) {
		isMoving = true;
		startTime = Time.time;

		switch(dir) {
		case Direction.Up:
			destination = transform.position + Vector3.up;
			break;
		case Direction.Down:
			destination = transform.position + Vector3.down;
			break;
		case Direction.Left:
			destination = transform.position + Vector3.left;
			break;
		case Direction.Right:
			destination = transform.position + Vector3.right;
			break;
		case Direction.Back:
			destination = transform.position + Vector3.back;
			break;
		case Direction.Front:
			destination = transform.position + Vector3.forward;
			break;
		}

		journeyLength = Vector3.Distance(transform.position, destination);
	}
}
