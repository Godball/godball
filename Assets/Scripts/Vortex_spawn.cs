using UnityEngine;
using System.Collections;

public class Vortex_spawn : MonoBehaviour
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

    void FixedUpdate()
    {
        pull();

        if ((Time.time - startTime) > lifespan)
            Destroy(gameObject);

    }

    void pull()
    {
            // calculate direction from target to vortex
            Vector3 forceDirection = transform.position - rb.GetComponent<Collider>().transform.position;

            // apply force on target towards vortex
            rb.AddForce(forceDirection.normalized * pullForce * Time.fixedDeltaTime);

    }
}
