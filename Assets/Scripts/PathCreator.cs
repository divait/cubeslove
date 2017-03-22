using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathCreator : MonoBehaviour {
	public enum Side {Up, Down, Left, Right, Front, Back};
	public enum Direction {Front, Back, Left, Right, None};

	public Side side;
	public Direction pathDirecton;

	// Use this for initialization
	void Start () {

		switch (pathDirecton) {
		case Direction.Front:
			transform.FindChild("up").gameObject.SetActive (true);
			transform.FindChild("down").gameObject.SetActive (false);
			transform.FindChild("right").gameObject.SetActive (false);
			transform.FindChild("left").gameObject.SetActive (false);
			break;
		case Direction.Back:
			transform.FindChild("up").gameObject.SetActive (false);
			transform.FindChild("down").gameObject.SetActive (true);
			transform.FindChild("right").gameObject.SetActive (false);
			transform.FindChild("left").gameObject.SetActive (false);
			break;
		case Direction.Right:
			transform.FindChild("up").gameObject.SetActive (false);
			transform.FindChild("down").gameObject.SetActive (false);
			transform.FindChild("right").gameObject.SetActive (true);
			transform.FindChild("left").gameObject.SetActive (false);
			break;
		case Direction.Left:
			transform.FindChild("up").gameObject.SetActive (false);
			transform.FindChild("down").gameObject.SetActive (false);
			transform.FindChild("right").gameObject.SetActive (false);
			transform.FindChild("left").gameObject.SetActive (true);
			break;
		default:
			transform.FindChild("up").gameObject.SetActive (false);
			transform.FindChild("down").gameObject.SetActive (false);
			transform.FindChild("right").gameObject.SetActive (false);
			transform.FindChild("left").gameObject.SetActive (false);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
