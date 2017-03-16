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
	
	// Update is called once per frame
	void Update () {
		
	}
}
