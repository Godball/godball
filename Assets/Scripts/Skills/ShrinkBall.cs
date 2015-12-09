﻿using UnityEngine;
using System.Collections;

public class ShrinkBall : Skill {
    
    public float shrinking;
    private Vector3 scale;
    public float duration;
    private Ray ray;

    void Activate ()
    {
        if (checkActive() && !checkOnCooldown()) // check if we can cast it
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray at mouse position

            if (Physics.Raycast(ray, floorMask)) // Check if ray intersects playingFieldLayer
            {
                scale = new Vector3(shrinking, shrinking, shrinking);
                rb.transform.localScale -= scale;

                startCooldown();

                Invoke("scaleUP", duration);
            }




            
        }
        
    }

    void scaleUP()
    {
        rb.transform.localScale += scale;
    }
}