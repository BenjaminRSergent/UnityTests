using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : MonoBehaviour
{
    public BoidController controller;
    public float maxForce = 50.0f;
    public float mass = 1.0f;
    public float maxSpeed = 100.0f;
    public Vector3 target;
    private Vector3 velocity = new Vector3();
    private List<IFlockingBehavior> flockingBehaviors = new List<IFlockingBehavior>();
    // Use this for initialization
    void Start()
    {
        controller.agents.Add(this);
        addBehavior(new SeekBehavior());
    }

    void OnDestroy()
    {
        controller.agents.Remove(this);
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 force = new Vector3();

        foreach (IFlockingBehavior behavior in flockingBehaviors) {
            force += behavior.GetDrivingForce(this);
        }

        force.y = 0; // No flying allowed yet

        if (force.sqrMagnitude > maxForce * maxForce) {
            force = force.normalized * maxForce / mass;
        }

        velocity += force * Time.deltaTime;

        if(velocity.sqrMagnitude > maxSpeed * maxSpeed) {
            velocity = velocity.normalized * maxSpeed;
        }

        transform.LookAt(transform.position + velocity);

        transform.position = transform.position + velocity * Time.deltaTime;
    }

    public void addBehavior(IFlockingBehavior behavior)
    {
        flockingBehaviors.Add(behavior);
        flockingBehaviors.Sort((x, y) => Comparer<int>.Default.Compare(x.Priority, y.Priority));
    }
}
