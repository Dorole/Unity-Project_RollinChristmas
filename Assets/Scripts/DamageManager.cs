using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour 
{
	public int Damage = 50;

	private void OnCollisionEnter(Collision collision)
	{
		//provjeravamo ima li objekt HealthManagera
		HealthManager otherHealthManager = collision.gameObject.GetComponent<HealthManager>();

		if (otherHealthManager == null)
			return;

		otherHealthManager.TakeDamage(Damage);

		//Destroy(gameObject);
	}


}

