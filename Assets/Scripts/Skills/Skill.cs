using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Skill : NetworkBehaviour
{
    public string skillName;
    public int skillNumber;
    public bool activeSkill;
    public float cooldownTime;
    public float skillStartTime;
    public float cooldownRemaining;
    public Rigidbody rb;
	public int floorMask;
    public Slider cooldown;
    public Image fillImage;
    public Color ready = Color.white;
    public Color notReady = Color.red;


    private GameObject skillbar;

    void Awake()
    {
        skillbar = transform.parent.gameObject; // get the skillbar
        cooldown.maxValue = cooldownTime;

        startCooldown();
        rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
		floorMask = LayerMask.GetMask ("PlayingArea"); // Player1Area & Player2Area are on the layer PlayingArea
    }

    // displays the cooldown
    void displayCoolDown()
    {
        
        if (cooldownRemaining > 0f)
        {
            cooldownRemaining = cooldownRemaining - Time.deltaTime;

            cooldown.value = cooldownRemaining;
            fillImage.color = notReady;

        } else
        {
            fillImage.color = ready;
        }
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
        return skillbar.GetComponent<SpellButtonsController>().spells[skillNumber];
    }

    void Update()
    {
        if (checkOnCooldown()) displayCoolDown();

    }
}

