using UnityEngine;
using System.Collections;

public class Teleport : Skill {

    public float distance;
    public GameObject teleportLight;
    private Ray ray;
    private Vector3 lightPos;

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
                PlaceLight(lightPos);
                startCooldown();
                StartCoroutine(FadeLight(0.6f));
            }
        }
    }

    void teleportBall(Vector3 direction)
    {
        direction = new Vector3(direction.x, 0f, direction.z);

        // if the ball is within max distance allowed
        if (direction.magnitude <= distance)
        {
            lightPos = rb.position + direction; // Save ball position to use for light position
            rb.position += direction;
            

        } else
        {
            // normalize and teleport max distance in the mouse direction
            direction.Normalize();
            direction = direction*distance;
            lightPos = rb.position + direction;
            rb.position += direction;
        }
    }

    void PlaceLight(Vector3 pos)
    {
        // Move Light above ball and set intencity to 8
        teleportLight.transform.position = new Vector3(pos.x, 7f, pos.z);
        teleportLight.GetComponent<Light>().intensity = 8;
    }

    IEnumerator FadeLight(float fTime)
    {
        // Current Intensity
        float intensity = teleportLight.GetComponent<Light>().intensity;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fTime)
        {
            // Interpolate intencity from max intensity to 0
            teleportLight.GetComponent<Light>().intensity = Mathf.Lerp(intensity, 0, t);
            // Wait one frame
            yield return null;
        }
       
    }
}
