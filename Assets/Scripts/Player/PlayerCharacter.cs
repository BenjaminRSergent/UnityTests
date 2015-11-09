using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
	int health = 5;
	// Use this for initialization
	void Start()
	{
	
	}

	void OnGUI()
	{
		float posX = 10;
		float posY = 10;
		GUI.Label(new Rect(posX, posY, 400, 100), "Health: " + health);
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void Hurt(int amount)
	{
		health -= amount;
	}
}
