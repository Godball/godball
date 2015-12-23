using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System;

public class PlayerScript : NetworkBehaviour {

    public Color SkillNotReady;
    public Color SkillReady;    

    public Skill[] skills = null;

    int activeSkill = -1;

    GameManager gameManager;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>().instance;
        try
        {
            gameManager.RegisterUser(this);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

        // Initialize the skills
        skills = new Skill[5];

        skills[0] = gameObject.GetComponent<Gust>();
        skills[1] = gameObject.GetComponent<Cyclone>();
        skills[2] = gameObject.GetComponent<Teleport>();
        skills[3] = gameObject.GetComponent<ShrinkBall>();
        skills[4] = gameObject.GetComponent<CreateWall>();
        activeSkill = 0;
        //Debug.LogError("I am " + this.ToString());
	}
	
	// Update is called once per frame
    [ClientCallback]
	void Update () {
        if (!isLocalPlayer)
            return;
        // Refine this. Do not allow it to trigger on clicks not positioned on the game board.
        if (Input.GetMouseButtonDown(0) && activeSkill != -1)
        {
            Debug.Log("Activating");
            skills[activeSkill].Use();
            //gameManager.InvokeSkill(this, activeSkill, args);
        }

        //displayCoolDown();
	}

    public void SelectSpell(int skillIndex)
    {
        //Debug.LogError("Selecting spell " + skillIndex + " which is " + skills[skillIndex].ToString());
        if (activeSkill != skillIndex)
        {
            foreach (Button b in GameObject.Find("Skillbar").GetComponentsInChildren<Button>()) {
                b.image.color = Color.white;
            }
            GameObject.Find("Skill " + skillIndex).GetComponent<Button>().image.color = Color.green;
            activeSkill = skillIndex;
            Debug.Log(activeSkill);
        }
    }

    void displayCoolDown()
    {
        // DOESN'T WORK!! Fix unique mappings
        GameObject[] sliders = GameObject.FindGameObjectsWithTag("SkillCooldownSlider");
        GameObject[] fills = GameObject.FindGameObjectsWithTag("SkillFill");
        for (int i = 0; i < skills.Length; i++ )
        {
            if (skills[i].CooldownRemaining > 0f)
            {
                skills[i].CooldownRemaining -= Time.deltaTime;

                sliders[i].GetComponent<Slider>().value = 1 - (skills[i].CooldownRemaining / skills[i].CooldownTime);
                fills[i].GetComponent<Image>().color = SkillNotReady;
            }
            else
            {
                fills[i].GetComponent<Image>().color = SkillReady;
            }
        }
    }
}
