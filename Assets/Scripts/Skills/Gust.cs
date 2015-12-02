using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Gust : Skill {

    public float speed = 100f;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 direction;

    [Command]
    void CmdPushBall(Vector3 direction)
    {
        rb.AddForce(direction * speed, ForceMode.Impulse);
    }

    void Activate()
    {
        if (checkActive() && !checkOnCooldown()) // check if we can cast it
        {

            StartCoroutine(mouseClick());
        }
    }

    IEnumerator mouseClick()
    {
        while (!Input.GetMouseButtonDown(0)) yield return null;
        startPosition = Input.mousePosition; // Get first mouse position

        StartCoroutine(mouseRelease()); // wait for release button, then continue
    }

    // coroutine, waits until mouse button is released
    IEnumerator mouseRelease()
    {
        while (!Input.GetMouseButtonUp(0)) yield return null;

        endPosition = Input.mousePosition;  // Get second mouse position
        direction = endPosition - startPosition; // Get direction
        direction.Normalize();  // Normalize the direction

        // Add force to gameObject
        rb.AddForce(direction * speed, ForceMode.Impulse);

        startCooldown();
        yield return new WaitForFixedUpdate();
    }
}
