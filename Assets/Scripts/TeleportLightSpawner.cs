using UnityEngine;
using System.Collections;

public class TeleportLightSpawner : MonoBehaviour
{

    public float fadeTime;
    public float startIntensity;
    float startTime;
    Light telpLight;

    // Use this for initialization
    void Start()
    {
        telpLight = GetComponent<Light>();
        telpLight.intensity = startIntensity;
        startTime = Time.time;
    }

    void Update()
    {
        float lerpTime = (Time.time - startTime)/fadeTime;
        telpLight.intensity = Mathf.Lerp(startIntensity, 0, lerpTime);
        if (telpLight.intensity <= 0)
            Destroy(gameObject);
    }
}
