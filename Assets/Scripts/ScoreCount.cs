using UnityEngine;
using UnityEngine.UI; // Needed to use Text
using UnityEngine.Networking;
using System.Collections;

public class ScoreCount : NetworkBehaviour {
	
	public Text player1Text;
	public Text player2Text;
    [SyncVar]
	private int player1Score;
    [SyncVar]
	private int player2Score;

	// Use this for initialization
	void Start () {
        player1Text = GameObject.Find("Player1Text").GetComponent<Text>();
        player2Text = GameObject.Find("Player2Text").GetComponent<Text>();
		player1Score = 0;
		player2Score = 0;
		SetCountText ();
	}

    [Server]
	public void Score1Plus1(){
		player1Score += 1;
	}

    [Server]
	public void Score2Plus1(){
		player2Score += 1;
	}

	public void SetCountText ()
	{
		player1Text.text = "Player 1:  " + player1Score.ToString();
		player2Text.text = "Player 2:  " + player2Score.ToString();
	}
}
