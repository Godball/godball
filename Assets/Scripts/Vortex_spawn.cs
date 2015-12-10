using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Vortex_spawn : NetworkBehaviour
{

    public int lifespan = 3;
    private float startTime;
    public float pullRadius;
    public float pullForce;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
        startTime = Time.time;
    }

    //[ClientCallback]
    void FixedUpdate()
    {
        Cmdpull();

        if ((Time.time - startTime) > lifespan)
            Destroy(gameObject);

    }

    void Cmdpull()
    {
        // calculate direction from target to vortex
        rb = GameObject.Find("TheBallOfGods").GetComponent<Rigidbody>();
        //Debug.LogError("RB: " + rb.ToString());
        //Debug.LogError("Trans: " + transform.ToString());
        Vector3 forceDirection = transform.position - rb.GetComponent<Collider>().transform.position;

        // apply force on target towards vortex
        rb.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);

    }
}
