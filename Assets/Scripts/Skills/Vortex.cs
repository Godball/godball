 using UnityEngine;
using System.Collections;

public class Vortex : Skill
{
    public Object prefab;
    private Vector3 mousePos;
    private Ray ray;
    private Plane plane = new Plane(Vector3.up, Vector3.zero);
    private float distance;

    void Activate()
    {
        if (checkActive() && !checkOnCooldown()) // check if we can cast it
        {
            mousePos = Input.mousePosition;
            ray = Camera.main.ScreenPointToRay(mousePos); // create a ray at mouse position

            if (plane.Raycast(ray, out distance)) // find where the ray intersects the playing field
            {
                Vector3 point = ray.GetPoint(distance); // get coordinates of intersection
                Instantiate(prefab, point, Quaternion.identity); // spawn the vortex
            }


            startCooldown();
        }
    }
}
