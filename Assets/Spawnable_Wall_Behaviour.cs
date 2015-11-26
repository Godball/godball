using UnityEngine;
using System.Collections;

public class Spawnable_Wall_Behaviour : MonoBehaviour {

    public float speed = 1.0F;
    public int lifespan = 3;

    private Vector3 startMarker;
    private Vector3 endMarker;
    private float startTime;
    private float journeyLength;
    void Start()
    {
        startTime = Time.time;
        startMarker = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z);
        endMarker = startMarker + new Vector3(0, 1, 0);
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }
    void Update()
    {
        if ((Time.time - startTime) > lifespan)
            Destroy(gameObject);


        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        Debug.Log(string.Format("Start: {0} - End: {1} - Frac: {2}", startMarker.ToString(), endMarker.ToString(), fracJourney.ToString()));
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
    }
}
