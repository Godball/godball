using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : NetworkBehaviour {

    PlayerScript _player1;
    PlayerScript _player2;

    [SyncVar]
    public Score score;

    public struct Score
    {
        [SyncVar]
        public int player1;
        [SyncVar]
        public int player2;

        public void GoalP1()
        {
            player1++;
        }

        public void GoalP2()
        {
            player2++;
        }
    }

    public GameManager instance;

    /// <summary>
    /// Property for player 1
    /// </summary>
    public PlayerScript Player1
    {
        get
        {
            return _player1;
        }
        set
        {
            _player1 = value;
        }
    }

    /// <summary>
    /// Property for player 2
    /// </summary>
    public PlayerScript Player2
    {
        get
        {
            return _player2;
        }
        set
        {
            _player2 = value;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        score = new Score();
    }

    /// <summary>
    /// Register a new player to the game.
    /// Throws exception if a third (3) player tries to join the game.
    /// </summary>
    /// <param name="player">PlayerScript object which will be tracked in this game instance.</param>
    public void RegisterUser(PlayerScript player)
    {
        if (Player1 == null)
            Player1 = player;
        else if (Player2 == null)
            Player2 = player;
        else
            throw new Exception("Third (3) player tried to join game");
    }

    public void InvokeSkill(PlayerScript _player, int _skill, System.Object[] arguments)
    {
        PlayerScript player = (Player1 != null && Player2 != null && _player.Equals(Player1)) ? Player1 : Player2;
        Debug.Log("Player: " + player);
        Debug.Log("Skill nr: " + _skill);
        Debug.Log("Skill: " + player.skills[_skill]);
        Debug.Log("Args: " + arguments);
        ServerCastSkill(player.skills[_skill], arguments);
        
    }

    void ServerCastSkill(Skill skill, System.Object[] args)
    {
        skill.CmdActivate(new Skill.Arguments());
    }

    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI ()
    {
        Text player1Text = GameObject.Find("Player1Text").GetComponent<Text>();
        Text player2Text = GameObject.Find("Player2Text").GetComponent<Text>();

        player1Text.text = "Player 1: " + score.player1;
        player2Text.text = "Player 2: " + score.player2;

        Debug.Log("Updating score, p1: " + score.player1);
    }
}
