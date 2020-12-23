using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour {

	public float moveSpeed = 5;

	Camera viewCamera;
	PlayerController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController> ();
		viewCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		// Movement input
		Vector3 moveinput = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		Vector3 moveVelocity = moveinput.normalized * moveSpeed;
		controller.Move(moveVelocity);

		// Look input
		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayDistance;

		if (groundPlane.Raycast(ray,out rayDistance)) {
			Vector3 point = ray.GetPoint(rayDistance);
			// Debug.DrawLine(ray.origin,point,Color.red);
			if(Input.GetMouseButtonDown(0)) {
				transform.position = point;
			}
		}

		

		// Projectile Input
	}
}
