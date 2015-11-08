using UnityEngine;
using System.Collections;

public class Seeker : MonoBehaviour, ILookTrigger {
	public GameObject player;
	public float chaseSpeed = 6.0f;
	public float wanderSpeed = 1.0f;
	public float minDist = 3.0f;
	public float damping = 0.99f;
	public AudioClip found;
	public AudioClip lost;

	AudioSource audio;
	private bool isLookedAt = false;
	private bool wasLookedAt = false;
	// Use this for initialization
	void Start() {
		audio = GetComponent<AudioSource>();
		RandomTurn();
	}
	
	// Update is called once per frame
	void Update() {
		if(isLookedAt) {
			if(!wasLookedAt) {
				audio.Stop();
				audio.PlayOneShot(found);
			}
			moveTowardPlayer();
		} else {

			if(wasLookedAt) {
				RandomTurn();
				audio.Stop();
				audio.PlayOneShot(lost);
			}

			transform.Translate(0, 0, wanderSpeed * Time.deltaTime);
			
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			const float RADIUS = 0.75f;
			if(Physics.SphereCast(ray, RADIUS, out hit)) {
				if(hit.distance < minDist) {
					RandomTurn();
				}
			}
		}

		wasLookedAt = isLookedAt;
		isLookedAt = false;
	}

	void RandomTurn() {
		float toTurn = Random.Range(-110, 100);
		transform.Rotate(0, toTurn, 0);
	}

	void moveTowardPlayer() {
		Vector3 toPlayer = player.transform.position - transform.position;
		toPlayer.y = 0;
		Quaternion rotation = Quaternion.LookRotation(toPlayer);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

		transform.Translate(0, 0, chaseSpeed * Time.deltaTime);
	}


	public void NotifyLooking() {
		isLookedAt = true;
	}

	void OnTriggerEntered(Collider other) {
		if(other.gameObject.GetComponent<PlayerCharacter>()) {
			Destroy(this);
		}
	}

}
