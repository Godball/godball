using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ShrinkBall : Skill {
    
    public float shrinking;
    private Vector3 scale;
    public float duration;
    private Ray ray;
	public AudioSource shrinkAudio;
    Rigidbody ball_rb;

    [Command]
    public override void CmdActivate(Arguments args)
    {
        if (!isOnCooldown()) // check if we can cast it
        {
            Vector3 point = GetClickPoint();
            if (!point.Equals(new Vector3()))
            {
                startCooldown();
                CmdscaleDown();
            }
        }
    }

    [Command]
    void CmdscaleDown()
    {
        scale = new Vector3(shrinking, shrinking, shrinking);
		shrinkAudio = GameObject.Find("audioShrink").GetComponent<AudioSource> ();
		shrinkAudio.Play();
        ball_rb.transform.localScale -= scale;
		duration = 3; //Added timeout value, outherwise ball was getting only bigger
        Invoke("CmdscaleUP", duration);
    }

    void CmdscaleUP()
    {
        ball_rb.transform.localScale += scale;
    }
}
