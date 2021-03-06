﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Teleport : Skill {

    public float distance;
    public Object teleportLight;
    private Ray ray;
    private Vector3 lightPos;
	public AudioSource teleportAudio;
    Rigidbody ball_rb;

    [Command]
    public override void CmdActivate(Arguments args)
    {
        if (!isOnCooldown()) // check if we can cast it
        {
            ball_rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
            Vector3 point = GetClickPoint();
            if (!point.Equals(new Vector3()))
            {
                startCooldown();
                Vector3 direction = point - ball_rb.position;
                CmdteleportBall(direction);
            }
        }
    }

    [Command]
    void CmdteleportBall(Vector3 direction)
    {
        direction = new Vector3(direction.x, 0f, direction.z);
        ball_rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
		teleportAudio = GameObject.Find("audioTeleport").GetComponent<AudioSource> ();

        // if the ball is within max distance allowed
        if (direction.magnitude <= distance)
        {
            lightPos = ball_rb.position + direction; // Save ball position to use for light position
            ball_rb.position += direction;
        } else
        {
            // normalize and teleport max distance in the mouse direction
            direction.Normalize();
            direction = direction*distance;
            lightPos = ball_rb.position + direction;
            ball_rb.position += direction;
        }
        Instantiate(teleportLight, new Vector3(lightPos.x, 7f, lightPos.z), Quaternion.Euler(90, 0, 0));
		teleportAudio.Play();
    }
}
