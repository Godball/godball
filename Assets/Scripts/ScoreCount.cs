using UnityEngine;
using UnityEngine.UI; // Needed to use Text
using System.Collections;

public class ScoreCount : MonoBehaviour {
	
	public Text player1Text;
	public Text player2Text;
	private int player1Score;
	private int player2Score;

	// Use this for initialization
	void Start () {
		player1Score = 0;
		player2Score = 0;
		SetCountText ();
	}

	public void Score1Plus1(){
		player1Score += 1;
	}

	public void Score2Plus1(){
		player2Score += 1;
	}

	public void SetCountText ()
	{
		player1Text.text = "Player 1:  " + player1Score.ToString();
		player2Text.text = "Player 2:  " + player2Score.ToString();
	}
}
