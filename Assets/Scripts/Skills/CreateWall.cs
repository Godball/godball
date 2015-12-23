using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreateWall : Skill 
{
    public Object prefab;
    private Vector3 mousePos;
    private Ray ray;
    private float distance;
	public AudioSource wallAudio;
    int floorMask;

    [Command]
    public override void CmdActivate(Arguments args)
    {
        if (!isOnCooldown()) // check if we can cast it
        {
            Vector3 point = new Vector3();
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
		wallAudio = GameObject.Find("audioWall").GetComponent<AudioSource> ();
		wallAudio.Play();

        //Debug.LogError("Obj: " + mag.ToString());
        NetworkServer.Spawn(mag);
    }

}
