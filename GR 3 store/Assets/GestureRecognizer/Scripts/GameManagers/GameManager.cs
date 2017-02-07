using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	 
	public Sprite win;
	public Sprite envelopeOpen;
	//public Sprite 
	public Sprite rectangle;
	public Sprite circle;
	public Sprite star;
	public Sprite diamond;

	private float timer;
	private float timeLeft;
	private Image taskImage;

	public string currentImg;
	public bool started;
	private GameObject playBtn;
	private GameObject playAgainBtn;
	private Text timerArea;
	private Text scoreText;

	private int score;
	//private 

	//public Sprite[] taskSprites;
	void Update(){
		if (started == true) {			

			if (timeLeft > 0) 
			{
				timeLeft -= Time.deltaTime; 
				timerArea.text = "Time left: " + Mathf.RoundToInt(timeLeft);
			}

			if (timeLeft <= 0 && started)
			{
				started = false;
				timerArea.text = "TIME IS UP!!!!";

				playAgainBtn.SetActive (true);
				//started = false;
				//SetMessage ("YOU lOOSE");
				//SceneManager.LoadScene ("EndPage");
			}
		}

	}

	public void IncreaseScore()
	{
		score++;
		scoreText.text = "Score " + score;
	}

	public void OnClickPlayButton()
	{
		started = true;
		SetNextImg("");
		timeLeft = timer;
		playBtn.SetActive (false);
		playAgainBtn.SetActive (false);
		score = 0;
		scoreText.text = "Score:"+score;
	}

	void Awake(){
		playBtn 		= GameObject.Find ("PlayButton");
		playAgainBtn 	= GameObject.Find ("PlayAgainButton");
		playAgainBtn.SetActive (false);
		timerArea 		= GameObject.Find ("TimerText").GetComponent<Text> ();
		scoreText 		= GameObject.Find ("Score Text").GetComponent<Text> ();
		taskImage 		= GameObject.Find ("TaskImage").GetComponent<Image> ();

		timer 			= 20;
		started 		= false;
		timerArea.text = "";
		scoreText.text = "";
		score = 0;


		if (instance == null)
			instance = this;
	}

public void SetNextImg (string imgName)
{
	Sprite nextTask;

		if (imgName.Equals ("rectangle")) {
			nextTask = star;
			currentImg = "star";
		} else if (imgName.Equals ("star")) {
			nextTask = circle;
			currentImg = "circle";
		} else if (imgName.Equals ("circle")) {
			nextTask = diamond;
			currentImg = "diamond";
		}else if (imgName.Equals ("diamond")) {
			nextTask = envelopeOpen;
			currentImg = "envelop_open";
		} 
		else {
			nextTask = rectangle;
			currentImg = "rectangle";
		}
	

	// set next image 
	taskImage.sprite = nextTask;


	}

}
