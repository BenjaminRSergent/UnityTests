using UnityEngine;
using System.Collections;

[AddComponentMenu("Control Script/FPS Input")]
public class MouseLook : MonoBehaviour {
	public float rotSpeedHor = 9.0f;
	public float rotSpeedVert = 9.0f;
	public float rotXMin = -45.0f;
	public float rotXMax = 45.0f;

	public RotationAxes axis = RotationAxes.MouseBoth;

	public enum RotationAxes {
		MouseBoth,
		MouseX,
		MouseY
	}

	private float rotationX;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (axis == RotationAxes.MouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * rotSpeedHor, 0);
		} else if (axis == RotationAxes.MouseY) {
			rotationX -= Input.GetAxis ("Mouse Y") * rotSpeedVert;
			rotationX = Mathf.Clamp (rotationX, rotXMin, rotXMax);

			transform.localEulerAngles = new Vector3 (rotationX, transform.localEulerAngles.y, 0);
		} else {
			rotationX -= Input.GetAxis ("Mouse Y") * rotSpeedVert;
			rotationX = Mathf.Clamp (rotationX, rotXMin, rotXMax);

			float deltaY = Input.GetAxis ("Mouse X") * rotSpeedHor;
			transform.localEulerAngles = new Vector3 (rotationX, transform.localEulerAngles.y + deltaY, 0);
		}
	}
}
