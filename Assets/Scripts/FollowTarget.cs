using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public float Speed;
	public Transform Target;
	//public float DistanceToKeep;
	public float MinDist;

	private Rigidbody _rigidbody;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
    {
		if (Target == null)
			_rigidbody.velocity = Vector3.zero;

		/*if (Target == null)
		{
			Target = GameObject.FindWithTag("Player").transform;

			if (Target == null)
				return;

		}*/

		transform.LookAt(Target);

		float distanceToTarget = Vector3.Distance(transform.position, Target.position);

		//if ((distanceToTarget > DistanceToKeep) || (distanceToTarget <= MinDist))
		if (distanceToTarget <= MinDist)
			transform.position += transform.forward * Speed * Time.deltaTime;

		if (distanceToTarget > MinDist)
			_rigidbody.velocity = Vector3.zero;


		

    }
}
