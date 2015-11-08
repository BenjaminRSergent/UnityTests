using UnityEngine;
using System.Collections;

public class NotifyLook : MonoBehaviour {
	public Camera myCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); 

		foreach(GameObject enemy in enemies) {
			ILookTrigger lookTrigger = enemy.GetComponent<ILookTrigger>();
			if(lookTrigger != null) {
				if(IsInView(enemy.transform.position)) {
					lookTrigger.NotifyLooking();
				}
			}
		}
	}

	bool IsInView (Vector3 position) {
		Vector2 screenCoord = myCamera.WorldToViewportPoint(position);

		return screenCoord.x >= 0 && screenCoord.x <= 1 &&
			   screenCoord.y >= 0 && screenCoord.y <= 1;
	}
}
