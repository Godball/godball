﻿using UnityEngine;
using System.Collections;

public class OnGoal : MonoBehaviour {

	private Rigidbody rb;
	public ScoreCount scoreCount; // Reference to other Script

	void Start()
	{
		scoreCount = gameObject.GetComponent<ScoreCount> ();
		rb = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider collision)
	{
		// Reset Ball Pos and Vel
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		transform.position = new Vector3(0,3,0);

		if (collision.gameObject.tag == "Player1Goal") 
		{
			Debug.Log("Player 2 SCORED!!!");
			scoreCount.Score2Plus1();
		}

		if (collision.gameObject.tag == "Player2Goal") 
		{
			Debug.Log("Player 1 SCORED!!!");
			scoreCount.Score1Plus1();
		}
		scoreCount.SetCountText ();
	}
}
