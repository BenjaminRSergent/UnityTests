using UnityEngine;
using System;

public interface IFlockingBehavior
{
    int Priority
    {
        get;
        set;
    }
    Vector3 GetDrivingForce(Agent agent);
}