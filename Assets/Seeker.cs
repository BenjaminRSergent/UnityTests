using UnityEngine;
using System.Collections;

public class Seeker : MonoBehaviour, ILookTrigger {
	public GameObject player;
	public float speed = 1.0f;
	private bool isLookedAt = false;
	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		if(isLookedAt) {
			moveTowardPlayer();
		}

		transform.LookAt(player.transform);

		isLookedAt = false;
	}

	void moveTowardPlayer() {
		Vector3 toPlayer = (player.transform.position - transform.position).normalized;
		toPlayer *= (speed * Time.deltaTime);
		transform.position = transform.position + toPlayer;
	}

	public void NotifyLooking() {
		isLookedAt = true;
	}

}
