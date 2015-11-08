using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ReactToHit() {
		StartCoroutine(Die());
	}

	private IEnumerator Die() {
		WanderBehavior wander = GetComponent<WanderBehavior>();

		if(wander != null) {
			wander.setAlive(false);
		}

		const float FALL_ANGLE = -80;
		const float MAX_FALL = 0.25f;
		float fallTime = MAX_FALL;
		const float WAIT_TIME = 1/60.0f;
		while(fallTime > 0) {		
			transform.Rotate(FALL_ANGLE/(MAX_FALL / WAIT_TIME), 0, 0);
			fallTime -= WAIT_TIME;
			yield return new WaitForSeconds(WAIT_TIME);
		}

		yield return new WaitForSeconds(0.5f);

		Destroy(gameObject);
	}
}
