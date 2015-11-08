using UnityEngine;
using System.Collections;

public class CameraShooter : MonoBehaviour {
	private Camera myCamera;
	// Use this for initialization
	void Start () {
		myCamera = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI() {
		int size = 12;
		float posX = myCamera.pixelWidth/2 - size / 4;
		float posY = myCamera.pixelHeight/2 - size / 2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 point = new Vector3(myCamera.pixelWidth/2, myCamera.pixelHeight/2, 0);
			Ray ray = myCamera.ScreenPointToRay(point);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				GameObject hitTarget = hit.transform.gameObject;
				ReactiveTarget target = hitTarget.GetComponent<ReactiveTarget>();
				if(target != null) {
					target.ReactToHit();
				} else {
					StartCoroutine(SphereIndicator(hit.point));
				}
			}
		
		}
	}

	private IEnumerator SphereIndicator(Vector3 position) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = position;

		Vector3 sphereScale = sphere.transform.localScale;
		sphereScale *= 2.0f;
		sphere.transform.localScale = sphereScale;

		float shrinkTime = 3.0f;
		const float WAIT_TIME = 1/30.0f;
		while(shrinkTime > 0) {		
			sphereScale *= 0.9f;
			sphere.transform.localScale = sphereScale;
			shrinkTime -= WAIT_TIME;
			yield return new WaitForSeconds(WAIT_TIME);
		}

		Destroy (sphere);
	}
}
