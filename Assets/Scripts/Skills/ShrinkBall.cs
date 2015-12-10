using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ShrinkBall : Skill {
    
    public float shrinking;
    private Vector3 scale;
    public float duration;
    private Ray ray;
	public AudioSource shrinkAudio;

    public override void Activate()
    {
        if (!checkOnCooldown()) // check if we can cast it
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray at mouse position

            if (Physics.Raycast(ray, floorMask)) // Check if ray intersects playingFieldLayer
            {
                CmdscaleDown();
                startCooldown();

                
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
