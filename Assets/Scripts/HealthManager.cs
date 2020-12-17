using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
	public int StartingHealth = 0; 
	public int Health = 0;
	public int NumberOfLives = 0;

	public Text LivesText;

	public Vector3 _startingPosition;

	private void Start()
	{
		Health = StartingHealth;
		_startingPosition = transform.position;

		int actualNumOfLives = NumberOfLives + 1;
		string stringNumberOfLives = actualNumOfLives.ToString();
		LivesText.text = $"LIVES: {stringNumberOfLives}";

	}

	public void TakeDamage(int damage)
 	{
		Health -= damage;
		if (Health < 0)
			Die();
	}


	public void Die()
	{
		
		Health = StartingHealth;
		NumberOfLives--;

		//transform = GetComponent<Transform>();    //ovo se izvršava u pozadini
		//transform.position = new Vector3(0.0f, 0.0f, 0.0f); sad umjesto toga:
		transform.position = _startingPosition;

		int actualNumOfLives = NumberOfLives + 1;
		string stringNumberOfLives = actualNumOfLives.ToString();
		LivesText.text = $"LIVES: {stringNumberOfLives}";

		if (NumberOfLives < 0)
		{
			if (gameObject.tag == "Player")
			{
				GameManager.Instance.GameOverCanvas.SetActive(true);
				FindObjectOfType<AudioManager>().Stop("Theme");
				FindObjectOfType<AudioManager>().Play("PlayerDeath");

				Destroy(gameObject);
			}

		}
	}




}
