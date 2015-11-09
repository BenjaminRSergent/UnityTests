using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	private GameObject enemyPrefab;
	private GameObject currEnemy;
	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if (currEnemy == null) {
			currEnemy = Instantiate(enemyPrefab) as GameObject;
			currEnemy.transform.position = new Vector3(0, 1, 0);
			currEnemy.transform.Rotate(0, Random.Range(0, 360), 0);
		}
	}
}
