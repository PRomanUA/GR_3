using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	private Text scoreText;
	private int score;

	void Awake()
	{
		scoreText = GameObject.Find ("Score Text").GetComponent<Text> (); 

		if (instance == null)
			instance = this;
	}

	public void IncreaseScore()
	{
		score++;
		scoreText.text = "" + score;
	}
}
