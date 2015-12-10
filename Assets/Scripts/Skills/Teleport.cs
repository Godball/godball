using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Teleport : Skill {

    public float distance;
    public Object teleportLight;
    private Ray ray;
    private Vector3 lightPos;

    public override void Activate()
    {
        if (!checkOnCooldown()) // check if we can cast it
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray at mouse position
            RaycastHit floorHit; // Store information about what was hit by the ray

            if (Physics.Raycast(ray, out floorHit, 100, floorMask)) // Check if ray intersects playingFieldLayer
            {
                Vector3 point = floorHit.point; // get coordinates of intersection
                Vector3 direction = point - ball_rb.position;

                CmdteleportBall(direction);
                
                startCooldown();
            }
        }
    }

    [Command]
    void CmdteleportBall(Vector3 direction)
    {
        direction = new Vector3(direction.x, 0f, direction.z);
        ball_rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
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
    }
}
