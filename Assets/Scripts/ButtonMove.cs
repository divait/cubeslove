using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour {

	public CubeController.Direction direction;

	private CubeController cube;

	void Start () {
		cube = transform.parent.parent.GetComponent<CubeController> ();
	}

	void OnMouseDown () {
		cube.startMove (direction);
	}
}
