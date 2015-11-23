using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SwipeAddForce : NetworkBehaviour {

	public float speed = 100f;
	private Vector2 startPosition;
	private Vector2 endPosition;
	private Vector2 direction;
	private Rigidbody rb;

	void Start()
	{
		rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody> ();
	}

    public override void OnStartLocalPlayer()
    {
        // Do things for the local player, such as color changes and other UI elements.
        base.OnStartLocalPlayer();
    }

    [Command]
    void CmdPushBall(Vector3 direction)
    {
        rb.AddForce(direction * speed, ForceMode.Impulse);
    }

    void Update() {
        if (!isLocalPlayer)
            return;

		if (Input.GetMouseButtonDown (0))
		{
			startPosition = Input.mousePosition; // Get first mouse position
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			endPosition = Input.mousePosition;	// Get second mouse position
			direction = endPosition - startPosition; // Get direction
			direction.Normalize();  // Normalize the direction
                                    //Debug.Log(direction.ToString());

            // Add force to gameObject
            CmdPushBall(new Vector3(direction.x, 0, direction.y));


		}
	}
}