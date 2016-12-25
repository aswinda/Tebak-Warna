using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour {

	string question;

	[SerializeField]
	private Text currentQuestion;
	[SerializeField]
	private Text scoreUI;
	[SerializeField]
	private Text timeLeftUI;

	[SerializeField]
	private Button button1;
	[SerializeField]
	private Button button2;
	[SerializeField]
	private Button button3;
	[SerializeField]
	private Button button4;

	[SerializeField]
	private GameObject panelGameOver;
	[SerializeField]
	private Text gameoverScoreUI;

	int level = 0;
	bool isGameOver = false;
	int score = 0;
	int timeDefault = 25;
	int timeMax = 25;
	int timeleft = 25;
	public float timeElapsed = 0f;

	static System.Random random;

	Color red = new Color (0.905f, 0.298f, 0.235f);
	Color green = new Color (0.180f, 0.803f, 0.443f);
	Color yellow = new Color (0.945f, 0.768f, 0.058f);
	Color blue = new Color (0.203f, 0.596f, 0.858f);

	// Use this for initialization
	void Start () {
		setQuestion ();

		scoreUI.text = score.ToString ();
		timeLeftUI.text = timeleft.ToString ();

		initButton ();

		panelGameOver.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= 0.1) 
		{
			timeleft -= 1;
			timeElapsed = 0f;
		}

		timeLeftUI.text = timeleft.ToString ();

		if (timeleft < 0)
			gameOver ();
	}

	void setQuestion()
	{
		random = new System.Random();

		string[] arr = new string[] 
		{
			"Blue",
			"Green",
			"Red",
			"Yellow"
		};

		string[] shuffle = RandomizeString (arr);
		question = shuffle[0];

		currentQuestion.text = question;
	}

	public void button1Click()
	{
		Debug.Log ("button 1 clicked");
		if (question == "Red") {
			if (button1.image.color == red)
				addScore ();
			else
				gameOver ();
		} else if (question == "Green") {
			if (button1.image.color == green)
				addScore ();
			else
				gameOver();
		} else if (question == "Blue") {
			if (button1.image.color == blue)
				addScore ();
			else
				gameOver();
		} else {
			if (button1.image.color == yellow)
				addScore ();
			else
				gameOver();
		}
	}

	public void button2Click()
	{
		Debug.Log ("button 2 clicked");
		if (question == "Red") {
			if (button2.image.color == red)
				addScore ();
			else
				gameOver();
		} else if (question == "Green") {
			if (button2.image.color == green)
				addScore ();
			else
				gameOver();
		} else if (question == "Blue") {
			if (button2.image.color == blue)
				addScore ();
			else
				gameOver();
		} else {
			if (button2.image.color == yellow)
				addScore ();
			else
				gameOver();
		}

	}

	public void button3Click()
	{
		Debug.Log ("button 3 clicked");
		if (question == "Red") {
			if (button3.image.color == red)
				addScore ();
			else
				gameOver();
		} else if (question == "Green") {
			if (button3.image.color == green)
				addScore ();
			else
				gameOver();
		} else if (question == "Blue") {
			if (button3.image.color == blue)
				addScore ();
			else
				gameOver();
		} else {
			if (button3.image.color == yellow)
				addScore ();
			else
				gameOver();
		}
	}

	public void button4Click()
	{
		Debug.Log ("button 4 clicked");
		if (question == "Red") {
			if (button4.image.color == red)
				addScore ();
			else
				gameOver();
		} else if (question == "Green") {
			if (button4.image.color == green)
				addScore ();
			else
				gameOver();
		} else if (question == "Blue") {
			if (button4.image.color == blue)
				addScore ();
			else
				gameOver();
		} else {
			if (button4.image.color == yellow)
				addScore ();
			else
				gameOver();
		}
	}

	void gameOver()
	{
		isGameOver = true;

		panelGameOver.SetActive (true);

		gameoverScoreUI.text = score.ToString ();
	}

	void initButton()
	{
		random = new System.Random();

		string[] arr = new string[] 
		{
			"Blue",
			"Green",
			"Red",
			"Yellow"
		};

		string[] shuffle = RandomizeString (arr);

		// button 1
		if (shuffle [0] == "Red") {
			button1 = changeButtonRed (button1);
		} else if (shuffle [0] == "Green") {
			button1 = changeButtonGreen (button1);
		} else if (shuffle [0] == "Blue") {
			button1 = changeButtonBlue (button1);
		} else {
			button1 = changeButtonYellow (button1);
		}

		// button 2
		if (shuffle [1] == "Red") {
			button2 = changeButtonRed (button2);
		} else if (shuffle [1] == "Green") {
			button2 = changeButtonGreen (button2);
		} else if (shuffle [1] == "Blue") {
			button2 = changeButtonBlue (button2);
		} else {
			button2 = changeButtonYellow (button2);
		}

		// button 3
		if (shuffle [2] == "Red") {
			button3 = changeButtonRed (button3);
		} else if (shuffle [2] == "Green") {
			button3 = changeButtonGreen (button3);
		} else if (shuffle [2] == "Blue") {
			button3 = changeButtonBlue (button3);
		} else {
			button3 = changeButtonYellow (button3);
		}

		// button 4
		if (shuffle [3] == "Red") {
			button4 = changeButtonRed (button4);
		} else if (shuffle [3] == "Green") {
			button4 = changeButtonGreen (button4);
		} else if (shuffle [3] == "Blue") {
			button4 = changeButtonBlue (button4);
		} else {
			button4 = changeButtonYellow (button4);
		}
	}


	static string[] RandomizeString(string[] arr)
	{
		List<KeyValuePair<int, string>> list = 
			new List<KeyValuePair<int, string>> ();

		foreach (string s in arr) 
		{
			list.Add (new KeyValuePair<int, string> (random.Next(), s));
		}

		var sorted = from item in list
		             orderby item.Key
		             select item;

		string[] result = new string[arr.Length];

		int index = 0;
		foreach (KeyValuePair<int, string> pair in sorted) 
		{
			result [index] = pair.Value;
			index++;
		}

		return result;
	}

	public void restartGame()
	{
		isGameOver = false;

		panelGameOver.SetActive (false);
		timeleft = timeDefault;
		timeMax = timeDefault;
		score = 0;
		scoreUI.text = score.ToString ();
	}

	void addScore()
	{
		score++;
		scoreUI.text = score.ToString ();

		timeleft = timeMax;

		setQuestion ();

		initButton ();

		if (timeMax >= 5)
			timeMax--;
	}


	Button changeButtonRed(Button button)
	{
		button.image.color = blue;

		button.GetComponentInChildren<Text> ().text = "Red";
		button.GetComponentInChildren<Text> ().color = red;

		return button;
	}

	Button changeButtonGreen(Button button)
	{
		button.image.color = yellow;

		button.GetComponentInChildren<Text> ().text = "Green";
		button.GetComponentInChildren<Text> ().color = green;

		return button;
	}

	Button changeButtonBlue(Button button)
	{
		button.image.color = red;

		button.GetComponentInChildren<Text> ().text = "Blue";
		button.GetComponentInChildren<Text> ().color = blue;

		return button;
	}

	Button changeButtonYellow(Button button)
	{
		button.image.color = green;

		button.GetComponentInChildren<Text> ().text = "Yellow";
		button.GetComponentInChildren<Text> ().color = yellow;

		return button;
	}
}
