using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Cyclone: Skill
{
    public Object prefab;
    private Vector3 mousePos;
    private Ray ray;
    private float distance;

	public AudioSource hurracaneAudio;

    [Command]
    public override void CmdActivate(Arguments args)
    {
        if (!isOnCooldown()) // check if we can cast it
        {
            Vector3 point = GetClickPoint();
            if (!point.Equals(new Vector3()))
            {
                startCooldown();
                Cmdspawnit(point);
            }
        }
    }

    [Command]
    void Cmdspawnit(Vector3 point)
    {
        GameObject mag = (GameObject)Instantiate(prefab, point, Quaternion.identity); // spawn the vortex
		hurracaneAudio = GameObject.Find("audioHurracane").GetComponent<AudioSource> ();
		hurracaneAudio.Play();
        //Debug.LogError("Obj: " + mag.ToString());
        NetworkServer.Spawn(mag);
    }
}
