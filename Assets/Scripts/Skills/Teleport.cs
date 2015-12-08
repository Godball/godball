using UnityEngine;
using System.Collections;

public class Teleport : Skill {

    public float distance;
    private Ray ray;


    void Activate()
    {
        if (checkActive() && !checkOnCooldown()) // check if we can cast it
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray at mouse position
            RaycastHit floorHit; // Store information about what was hit by the ray

            if (Physics.Raycast(ray, out floorHit, 100, floorMask)) // Check if ray intersects playingFieldLayer
            {
                Vector3 point = floorHit.point; // get coordinates of intersection
                Vector3 direction = point - rb.position;

                teleportBall(direction);
                startCooldown();
            }


        }
    }

    void teleportBall(Vector3 direction)
    {
        direction = new Vector3(direction.x, 0f, direction.z);
        
        // if the ball is within max distance allowed
        if (direction.magnitude <= distance)
        {
            rb.position += direction;
        } else
        {
            // normalize and teleport max distance in the mouse direction
            direction.Normalize();
            direction = direction*distance;
            rb.position += direction;
        }

    }


}
