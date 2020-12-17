using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetImmediate : MonoBehaviour
{
	public float Speed;
	public Transform Target;
	public float DistanceToKeep;
    
    private void Update()
    {
        if (Target == null)
            return;

        FollowTarget();

    }

    public void FollowTarget()
    {
        Target = GameObject.FindWithTag("Player").transform;

        transform.LookAt(Target);

        float distanceToTarget = Vector3.Distance(transform.position, Target.position);

        if (distanceToTarget > DistanceToKeep)
            transform.position += transform.forward * Speed * Time.deltaTime;
    }
}
