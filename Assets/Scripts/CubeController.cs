using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	public enum Direction {Up, Down, Left, Right, Front, Back};

	public float speed = 0.2f;
	public Vector3 initialPostion;

	private GameController gameController;
	private Transform controls;
	private float startTime;
	private float journeyLength;
	private Vector3 destination;
	private bool isMoving;

	void Start() {
		isMoving = false;
		gameController = transform.parent.GetComponent<GameController> ();
		controls = transform.FindChild ("Controls");
	}

	void Update() {

		if (isMoving) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;

			transform.position = Vector3.Lerp(transform.position, destination, fracJourney);

			if (transform.position == destination)
				isMoving = false;
		}
	}


	public void startMove (Direction dir) {
		if (!isMoving) {
			isMoving = true;
			startTime = Time.time;

			switch (dir) {
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

			journeyLength = Vector3.Distance (transform.position, destination);
		}
	}

	public void showControllHitFace(RaycastHit hit)
	{
		Vector3 incomingVec = hit.normal - Vector3.up;

		if (incomingVec == new Vector3 (0, -1, -1)) { // Front
			controls.localPosition = new Vector3 (0, 0, -0.6f);
			controls.rotation = Quaternion.Euler (new Vector3 (-90, 0, 0));
			ChangeControls (Direction.Front);
		} else if (incomingVec == new Vector3 (0, -1, 1)) { // Back
			controls.localPosition = new Vector3 (0, 0, 0.6f);
			controls.rotation = Quaternion.Euler (new Vector3 (-90, 180, 180));
			ChangeControls (Direction.Back);
		} else if (incomingVec == new Vector3 (0, 0, 0)) { // Up
			controls.localPosition = new Vector3 (0, 0.6f, 0);
			controls.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
			ChangeControls (Direction.Up);
		} else if (incomingVec == new Vector3 (0, -2, 0)) { // Down
			controls.localPosition = new Vector3 (0, -0.6f, 0);
			controls.rotation = Quaternion.Euler (new Vector3 (180, 180, 180));
			ChangeControls (Direction.Down);
		} else if (incomingVec == new Vector3 (-1, -1, 0)) { // Left
			controls.localPosition = new Vector3 (-0.6f, 0, 0);
			controls.rotation = Quaternion.Euler (new Vector3 (-90, 180, 90));
			ChangeControls (Direction.Left);
		} else if (incomingVec == new Vector3 (1, -1, 0)) { // Right
			controls.localPosition = new Vector3 (0.6f, 0, 0);
			controls.rotation = Quaternion.Euler (new Vector3 (-90, 0, -90));
			ChangeControls (Direction.Right);
		}
	}

	void ChangeControls(Direction dir) {
		ButtonMove up = controls.FindChild ("up").GetComponent<ButtonMove> ();
		ButtonMove down = controls.FindChild ("down").GetComponent<ButtonMove> ();
		ButtonMove right = controls.FindChild ("right").GetComponent<ButtonMove> ();
		ButtonMove left = controls.FindChild ("left").GetComponent<ButtonMove> ();

		switch (dir) {
		case Direction.Up:
		case Direction.Down:
			up.direction = Direction.Front;
			down.direction = Direction.Back;
			right.direction = Direction.Right;
			left.direction = Direction.Left;
			break;
		case Direction.Left:
		case Direction.Right:
			up.direction = Direction.Up;
			down.direction = Direction.Down;
			right.direction = Direction.Front;
			left.direction = Direction.Back;
			break;
		case Direction.Back:
		case Direction.Front:
			up.direction = Direction.Up;
			down.direction = Direction.Down;
			right.direction = Direction.Right;
			left.direction = Direction.Left;
			break;
		}
	}
}
