using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
	public BoidController controller;
	// Use this for initialization
	void Start()
	{
	
	}

	void OnGUI()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		foreach (Agent agent in controller.agents) {
			agent.target = transform.position;
		}
	}
}
