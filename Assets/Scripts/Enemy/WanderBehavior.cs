using UnityEngine;
using System.Collections;

public class WanderBehavior : MonoBehaviour {
	public float min_dist = 5.0f;
	public float speed = 3.0f;
	private bool alive;
	[SerializeField] GameObject fireballPrefab;
	private GameObject fireBall;
	// Use this for initialization
	void Start () {
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(alive) {
			transform.Translate(0, 0, speed * Time.deltaTime);
			
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			const float RADIUS = 0.75f;
			if(Physics.SphereCast(ray, RADIUS, out hit)) {
				if(fireBall == null && hit.transform.gameObject.GetComponent<PlayerCharacter>()) {
					fireBall = Instantiate(fireballPrefab) as GameObject;
					fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
					fireBall.transform.rotation = transform.rotation;
				} if(hit.distance < min_dist) {
					float toTurn = Random.Range(-110, 100);
					transform.Rotate(0, toTurn, 0);
				}
			}
		}
	}
	
	public void setAlive(bool val) {
		alive = val;
	}
}
