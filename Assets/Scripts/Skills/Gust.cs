using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Gust : Skill 
{
    public float speed = 100f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 direction;
    //Rigidbody ball_rb;

    [Command]
    void CmdPushBall(Vector3 direction) // Sync with server
    {
        ball_rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
        ball_rb.AddForce(direction * speed, ForceMode.Impulse);
    }

    public override void Activate()
    {
        if (!checkOnCooldown()) // check if we can cast it
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

		Debug.Log (direction);

        // Add force to gameObject
        //rb.AddForce(direction * speed, ForceMode.Impulse);
		CmdPushBall (new Vector3 (direction.x, 0, direction.y));

        startCooldown();
        yield return new WaitForFixedUpdate();
    }
}
