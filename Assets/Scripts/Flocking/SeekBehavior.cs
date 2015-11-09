using UnityEngine;
using System;

public class SeekBehavior : IFlockingBehavior
{
    public int Priority
    {
        get;
        set;
    }
    public Vector3 GetDrivingForce(Agent agent) {
        return (agent.target - agent.transform.position).normalized * agent.maxForce;
    }
}