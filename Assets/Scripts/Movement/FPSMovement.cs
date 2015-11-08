using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSMovement : MonoBehaviour {
	public float gravity = -9.8f;
	public float movementSpeed = 1.0f;
	public float jumpForce = 100.0f;
	public float jumpDuration = 1.0f;

	private float jumpTime = 0.0f;

	private CharacterController charController;

	// Use this for initialization
	void Start () {
		charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * movementSpeed;
		float deltaZ = Input.GetAxis ("Vertical") * movementSpeed;

		Vector3 movement = new Vector3(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
		movement = Vector3.ClampMagnitude (movement, movementSpeed);
		movement.y = gravity;

		
		if(Input.GetKeyDown(KeyCode.Space) && charController.isGrounded) {
			jumpTime = jumpDuration;
			Debug.Log("Jumping");
		}
		
		if (jumpTime > 0.0f) {
			jumpTime -= Time.deltaTime;
			movement.y += jumpForce * jumpTime/jumpDuration;
			Debug.Log("Applying Force");
		}

		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		charController.Move (movement);

	}
}
