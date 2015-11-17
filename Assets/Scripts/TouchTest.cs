using UnityEngine;
using System.Collections;

public class TouchTest : MonoBehaviour {

	public float speed = 100f;
	private Vector2 startPosition;
	private Vector2 endPosition;
	private Vector2 direction;
	private Rigidbody rb;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void Update() {
		if (Input.GetMouseButtonDown (0))
		{
			startPosition = Input.mousePosition; // Get first mouse position
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			endPosition = Input.mousePosition;	// Get second mouse position
			direction = endPosition - startPosition; // Get direction
			direction.Normalize();	// Normalize the direction
			//Debug.Log(direction.ToString());

			// Add force to gameObject
			rb.AddForce(new Vector3(direction.x,0,direction.y)*speed,ForceMode.VelocityChange);


		}
	}
}