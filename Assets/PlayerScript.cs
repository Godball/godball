using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class PlayerScript : NetworkBehaviour {

    public Color SkillNotReady;
    public Color SkillReady;    

    public Skill[] skills = null;

    Skill activeSkill = null;

	// Use this for initialization
	void Start () {

        // Initialize the skills
        skills = new Skill[5];

        skills[0] = gameObject.GetComponent<Gust>();
        skills[1] = gameObject.GetComponent<Cyclone>();
        skills[2] = gameObject.GetComponent<Teleport>();
        skills[3] = gameObject.GetComponent<ShrinkBall>();
        skills[4] = gameObject.GetComponent<CreateWall>();
        //Debug.LogError("I am " + this.ToString());
	}
	
	// Update is called once per frame
    [ClientCallback]
	void Update () {
        if (!isLocalPlayer)
            return;
        // Refine this. Do not allow it to trigger on clicks not positioned on the game board.
        if (Input.GetMouseButtonDown(0) && activeSkill != null)
        {
            Debug.Log("Activating");
            activeSkill.Activate();
        }

        displayCoolDown();
	}

    public void SelectSpell(int skillIndex)
    {
        //Debug.LogError("Selecting spell " + skillIndex + " which is " + skills[skillIndex].ToString());
        if (activeSkill != skills[skillIndex])
        {
            foreach (Button b in GameObject.Find("Skillbar").GetComponentsInChildren<Button>()) {
                b.image.color = Color.white;
            }
            GameObject.Find("Skill " + skillIndex).GetComponent<Button>().image.color = Color.green;
            activeSkill = skills[skillIndex];
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
            if (skills[i].cooldownRemaining > 0f)
            {
                skills[i].cooldownRemaining -= Time.deltaTime;

                sliders[i].GetComponent<Slider>().value = 1 - (skills[i].cooldownRemaining / skills[i].cooldownTime);
                fills[i].GetComponent<Image>().color = SkillNotReady;
            }
            else
            {
                fills[i].GetComponent<Image>().color = SkillReady;
            }
        }
    }
}
