using UnityEngine;
using System.Collections;

public class SpawnSeeker : MonoBehaviour {
	[SerializeField] private GameObject seekerPrefab;
	public GameObject player;
	public int toSpawn = 3;
	// Use this for initialization
	void Start () {
		for(int index = 0; index < toSpawn; index++) {
			GameObject seeker = Instantiate(seekerPrefab) as GameObject;
			seeker.transform.position = new Vector3(Random.Range(-6, 6), 1, Random.Range(-6, 6));
			seeker.GetComponent<Seeker>().player = player;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
