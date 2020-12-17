using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public int Score = 0;
	public Text ScoreText;
	public int ScoreGoalForNextLevel = 50;

	public GameObject GameOverCanvas;
	public GameObject MainMenuCanvas;
	public GameObject GameplayCanvas;
	public GameObject TutorialCanvas;
	public GameObject NextLevelCanvas;
	public GameObject WinCanvas;

	public GameObject Player;

	private void Awake()
	{
		if (Instance != null)
			Destroy(gameObject);

		Instance = this;

		MainMenuCanvas.SetActive(true);
		GameplayCanvas.SetActive(true);
		WinCanvas.SetActive(true);
		GameOverCanvas.SetActive(false);
		NextLevelCanvas.SetActive(false);

		Player.SetActive(false);
	}

	public void UpdateScore(int value)
	{
		Score += value;

		if (Score < 0)
			Score = 0;

		ScoreText.text = Score.ToString();

		if (Score >= ScoreGoalForNextLevel)
		{
			Player.SetActive(false);
			NextLevelCanvas.SetActive(true);

		}
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		FindObjectOfType<AudioManager>().Play("Theme");
	}

	public void ExitGame()
    {
		Application.Quit();
    }

	public void StartGame()
    {
		GameplayCanvas.SetActive(true);
		TutorialCanvas.SetActive(true);
		GameOverCanvas.SetActive(false);
		NextLevelCanvas.SetActive(false);

		Player.SetActive(false);

		//FindObjectOfType<AudioManager>().Stop("Theme");
		SceneManager.LoadScene(1);
		FindObjectOfType<AudioManager>().Play("Theme");
		
	}

	public void HideTutorial()
    {
		TutorialCanvas.SetActive(false);
		Player.SetActive(true);

    }

	public void BackToMenu()
    {
		SceneManager.LoadScene(0);

	}

	public void NextLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
