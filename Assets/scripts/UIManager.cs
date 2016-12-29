using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public Button[] buttons;
	public Text scoreText;
	bool gameOver;
	int score = 0;

	// Use this for initialization
	void Start () {
		gameOver = false;
		score = 0;
		InvokeRepeating ("scoreUpdate", .5f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}

	public void play(){

		Application.LoadLevel ("racing2d");

	}

	public void pause(){
		if (Time.timeScale == 1) {
			//Running
			Time.timeScale = 0;
		} else {
			//paused
			Time.timeScale = 1;
		}

	}

	public void gameOverx(){
		gameOver = true;
		foreach(Button button in buttons){
			button.gameObject.SetActive(true);
		}

	}

	void scoreUpdate(){

		if (!gameOver) {
			score += 1;
		}
	}


	public void Menu(){

		Application.LoadLevel ("menuScene");

	}

	public void Exit(){
		Application.Quit();
	}
}
