using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static bool isGameOn = false;
	public GameObject startMenu;
	public GameObject settingsMenu;
	public GameObject aboutMenu;
	public GameObject gameOverMenu;
	public GameObject gamePanel;
	public Decorator levelDecorator;

	bool gameState;
	GameObject hero;	

	void Awake() 
	{
		hero = GameObject.FindGameObjectWithTag("Player");
		GameModeOn (false);
	}

	void Show(GameObject go)
	{
		go.GetComponent<RectTransform>().localPosition = Vector3.zero;
	}

	void Hide(GameObject go)
	{
		go.GetComponent<RectTransform>().localPosition = new Vector3(10000, 0, 0);
	}

	public void QuitGame() 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
		Application.Quit();
	}

	public void Play() 
	{
		GameModeOn(true);
		Hide(startMenu);
	}

	public void Stop() 
	{
		GameModeOn(false);
		RestoreToStartValues();
		Show(startMenu);
	}
	
	public void ShowSettingsMenu()
	{
		gameState = isGameOn;
		GameModeOn(false);
		Show(settingsMenu);
	}

	public void HideSettingsMenu()
	{
		GameModeOn(gameState);
		Hide(settingsMenu);
	}

	public void ShowAboutMenu()
	{
		Show(aboutMenu);
	}

	public void HideAboutMenu()
	{
		Hide(aboutMenu);
	}

	public void Restart() 
	{
		RestoreToStartValues();
		levelDecorator.ResetLevel ();
		Hide(gameOverMenu);
		GameModeOn(true);
	}

	public void GameOver()
	{
		GameModeOn(false);
		BestScore();
		Show(gameOverMenu);
	}

	private void BestScore()
	{
		var gameOverMessage = "Current score: " + Balance.Current + "\n";
		gameOverMessage += "Best score: " + Balance.Best;
		GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>().text = gameOverMessage;
	}

	public void GameModeOn(bool isInGame) 
	{
		gamePanel.SetActive(isInGame);
		hero.SetActive (isInGame);
		isGameOn = isInGame;
		Time.timeScale = isInGame ? 1 : 0;
	}

	void Update() 
	{
		if (hero.GetComponent<Health>().isDead())
			GameOver();
	}

	void RestoreToStartValues() 
	{
		Balance.Current = 0;
		hero.GetComponent<Health>().RestoreHealth();
		hero.GetComponent<HeroController>().RestoreHeroPosition();
	}
}
