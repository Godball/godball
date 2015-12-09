using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class PlayerScript : NetworkBehaviour {

    
    public Skill skill0;
    public Skill skill1;
    public Skill skill2;
    public Skill skill3;
    public Skill skill4;

    public Skill[] skills = null;

    Skill activeSkill = null;

	// Use this for initialization
	void Start () {

        // Initialize the skills
        skills = new Skill[5];
        skills[0] = skill0;
        skills[1] = skill1;
        skills[2] = skill2;
        skills[3] = skill3;
        skills[4] = skill4;

        skill0 = gameObject.AddComponent<Gust>();
	}
	
	// Update is called once per frame
	void Update () {
        // Refine this. Do not allow it to trigger on clicks not positioned on the game board.
        if (Input.GetMouseButtonDown(0) && activeSkill != null)
        {
            Debug.Log("Activating");
            activeSkill.Activate();
        }
	}

    public void SelectSpell(int skillIndex)
    {
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
}
