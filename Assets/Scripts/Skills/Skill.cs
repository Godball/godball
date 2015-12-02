using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Skill : NetworkBehaviour

{
    
    public string skillName;
    public float skillNumber;
    public bool activeSkill;
    public float cooldownTime;
    public float skillStartTime;
    public float cooldownRemaining;
    public Rigidbody rb;


    private GameObject skillbar;

    void Awake()
    {
        skillbar = transform.parent.gameObject; // get the skillbar
        skillStartTime = 0;
        rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
    }

    

    // displays the cooldown
    void displayCoolDown()
    {
        if (cooldownRemaining > 0)
        {
            cooldownRemaining = cooldownRemaining - Time.deltaTime;
        }
          
        // TODO: display cooldownRemaining in a nice way

    }

    public void startCooldown()
    {
        skillStartTime = Time.time;
        cooldownRemaining = cooldownTime;
    }

    // checks if the skill is on cooldown or not
    public bool checkOnCooldown()
    {
        if (Time.time > skillStartTime + cooldownTime)
        {
            return false;
        } else
        {
            return true;
        }
    }

    // checks if the skill is active
    public bool checkActive()
    {
        if (skillNumber == 1) return skillbar.GetComponent<SpellButtonsController>().spell1;
        if (skillNumber == 2) return skillbar.GetComponent<SpellButtonsController>().spell2;
        if (skillNumber == 3) return skillbar.GetComponent<SpellButtonsController>().spell3;
        if (skillNumber == 4) return skillbar.GetComponent<SpellButtonsController>().spell4;
        return false;
    }

    void Update()
    {
        if (checkOnCooldown()) displayCoolDown();

    }
}

