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
    public Rigidbody ball_rb;
	public int floorMask;

    void Awake()
    {
        //skillbar = transform.parent.gameObject; // get the skillbar
        //cooldown.maxValue = cooldownTime;

        startCooldown();
        //ball_rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
		floorMask = LayerMask.GetMask ("PlayingArea"); // Player1Area & Player2Area are on the layer PlayingArea
    }

    [Command]
    public void CmdSpawnOnServer(GameObject obj)
    {
        Debug.LogError("Obj: " + obj.ToString());
        NetworkServer.Spawn(obj);
    }

    public void startCooldown()
    {
        skillStartTime = Time.time;
        cooldownRemaining = cooldownTime;
    }

    // checks if the skill is on cooldown or not
    public bool checkOnCooldown()
    {
        Debug.Log("Checking " + Time.time + " > " + (skillStartTime + cooldownTime));
        return (Time.time < skillStartTime + cooldownTime);
    }

    public virtual void Activate(){}
}

