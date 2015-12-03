using UnityEngine;
using System.Collections;

public class RotateAroundY : MonoBehaviour {

	public float rotationAmount = 10f;

	// Update is called once per frame
	void Update () {
	
		transform.Rotate (0, rotationAmount * Time.deltaTime, 0);
	}
}
