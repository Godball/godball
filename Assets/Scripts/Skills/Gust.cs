using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


/// <summary>
/// Gust is the primary spell used to move the ball.
/// The spell applies force to the ball in a given direction by swiping on the screen.
/// </summary>
public class Gust : Skill 
{
    /// <summary>
    /// The speed with which the force is applied.
    /// </summary>
    public float _speed = 100f;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Rigidbody _ball = null;	

    /// <summary>
    /// Push the ball with force in the given direction.
    /// </summary>
    /// <param name="direction">Direction of the force.</param>
    /// <param name="speed">Speed used to calculate force.</param>
    void PushBall(Vector3 direction, float speed)
    {
        _ball = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
        _ball.AddForce(direction * speed, ForceMode.Force);
    }

    /// <summary>
    /// If the skill is not on cooldown, activate it to push the ball.
    /// </summary>
    [Command]
    public override void CmdActivate(Arguments args)
    {
        Vector3 direction = args.endPosition - args.startPosition; // Get direction
        direction.Normalize();  // Normalize the direction

        // Add force to gameObject
		PushBall (new Vector3 (direction.x, 0, direction.y), args.speed);
    }

    public override void Use()
    {
        if (!isOnCooldown())
            StartCoroutine(mouseClick(new Arguments()));
    }

    /// <summary>
    /// Waits until the mouse is clicked, then start another coroutine.
    /// </summary>
    /// <returns></returns>
    IEnumerator mouseClick(Arguments args)
    {
        while (!Input.GetMouseButtonDown(0)) yield return null;
        args.speed = _speed; // Use the correct speed.
        args.startPosition = Input.mousePosition; // Get first mouse position
        StartCoroutine(mouseRelease(args)); // wait for release button, then continue
    }

    /// <summary>
    /// Wait until mouse is released, then call the PushBall method to apply force.
    /// </summary>
    /// <returns></returns>
    IEnumerator mouseRelease(Arguments args)
    {
        while (!Input.GetMouseButtonUp(0)) yield return null;
        args.endPosition = Input.mousePosition;  // Get second mouse position
        Debug.Log(Audio);
        Audio.PlayOneShot(Audio.clip);
		Audio.Play(); // Play skill sound

        // Invoke the skill
        CmdActivate(args);
        startCooldown();
        
        yield return new WaitForFixedUpdate();
    }
}
