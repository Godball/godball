﻿using UnityEngine;
using System.Collections;

public class CreateWall : Skill 
{
    public Object prefab;
    private Vector3 mousePos;
    private Ray ray;
    private float distance;

    void Activate()
    {
        if (checkActive() && !checkOnCooldown()) // check if we can cast it
        {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray at mouse position
			RaycastHit floorHit; // Store information about what was hit by the ray

            if (Physics.Raycast(ray, out floorHit, 100, floorMask)) // Check if ray intersects playingFieldLayer
            {
				Vector3 point = floorHit.point; // get coordinates of intersection
                Instantiate(prefab, point, Quaternion.identity); // spawn the wall

                startCooldown();
            }


        }

    }

}