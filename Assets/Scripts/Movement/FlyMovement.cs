using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FlyMovement : MonoBehaviour
{
	public float gravity = -9.8f;
	public float movementSpeed = 400.0f;
	private CharacterController charController;
	
	// Use this for initialization
	void Start()
	{
		charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update()
	{
		float deltaX = Input.GetAxis("Horizontal") * movementSpeed;
		float deltaY = 0;
		float deltaZ = Input.GetAxis("Vertical") * movementSpeed;
		
		if (Input.GetKey(KeyCode.Space)) {
			deltaY += movementSpeed;
		}
		if (Input.GetKey(KeyCode.LeftControl)) {
			deltaY -= movementSpeed;
		}
		
		Vector3 movement = new Vector3(deltaX * Time.deltaTime, deltaY * Time.deltaTime, deltaZ * Time.deltaTime);

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);
		
	}
}