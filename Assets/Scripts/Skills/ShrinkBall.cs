using UnityEngine;
using System.Collections;

public class ShrinkBall : Skill {
    
    public float shrinking;
    private Vector3 scale;
    public float duration;

    void Activate ()
    {
        if (checkActive() && !checkOnCooldown()) // check if we can cast it
        {
            scale = new Vector3(shrinking, shrinking, shrinking);
            rb.transform.localScale -= scale;

            startCooldown();
            
            Invoke("scaleUP", duration) ;
            
        }
        
    }

    void scaleUP()
    {
        rb.transform.localScale += scale;
    }
}
