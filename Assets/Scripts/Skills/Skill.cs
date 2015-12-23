using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// Class which all skills in the game inherits from.
/// Provides the Activate() method which all children must override.
/// </summary>
public class Skill : NetworkBehaviour
{

    public struct Arguments
    {
        public Vector3 startPosition;
        public Vector3 endPosition;

        public float speed;
    }

    /// <summary>
    /// DO NOT USE. Use the SkillName property instead.
    /// </summary>
    public string _skillName;

    /// <summary>
    /// DO NOT USE. Use the CooldownTime property instead.
    /// </summary>
    public float _cooldownTime;

    /// <summary>
    /// DO NOT USE. Use the Audio property instead.
    /// </summary>
    public AudioSource _audio;

    private float _cooldownStarted;
    private float _cooldownRemaining;

    /// <summary>
    /// Name of the skill to be displayed on the screen.
    /// </summary>
    /// <value>Property gets/sets the value of the string _skillName</value>
    public string SkillName
    {
        get
        {
            return _skillName;
        }
        set
        {
            _skillName = value;
        }
    }

    /// <summary>
    /// The base value for the cooldown in seconds.
    /// </summary>
    public float CooldownTime
    {
        get
        {
            return _cooldownTime;
        }
        set
        {
            _cooldownTime = value;
        }
    }

    /// <summary>
    /// Point in time when the skill is triggered. Set in runtime.
    /// </summary>
    public float CooldownStarted
    {
        get
        {
            return _cooldownStarted;
        }
        set
        {
            _cooldownStarted = value;
        }
    }

    /// <summary>
    /// Cooldown time remaining. Calculated in runtime.
    /// </summary>
    public float CooldownRemaining
    {
        get
        {
            return _cooldownRemaining;
        }
        set
        {
            _cooldownRemaining = value;
        }
    }

    /// <summary>
    /// The AudioSource of the skill.
    /// </summary>
    public AudioSource Audio
    {
        get
        {
            return _audio;
        }
        set
        {
            _audio = value;
        }
    }

    /// <summary>
    /// Puts the skill on cooldown.
    /// </summary>
    public void startCooldown()
    {
        CooldownStarted = Time.time;
        CooldownRemaining = CooldownTime;
    }

    
    /// <summary>
    /// Checks if the skill is currently on cooldown.
    /// </summary>
    /// <returns>Bool. True: On cooldown. False: Not on cooldown.</returns>
    public bool isOnCooldown()
    {
        return (Time.time < CooldownStarted + CooldownTime);
    }

    /// <summary>
    /// Activates the skill on the server.
    /// </summary>
    /// <param name="args">Data sent to the activated skill.
    /// [0]: Mouse down pos
    /// [1]: Mouse up pos
    /// </param>
    [Command]
    public virtual void CmdActivate(Arguments args){}

    /// <summary>
    /// Prepare the data to be sent to the server.
    /// </summary>
    public virtual void Use() {}

    /// <summary>
    /// Gets the point on the PlayingArea which was clicked.
    /// </summary>
    /// <returns>If intersection with valid area occured, point. Else, a new Vector3.</returns>
    public Vector3 GetClickPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray at mouse position
        RaycastHit floorHit; // Store information about what was hit by the ray
        int floorMask = LayerMask.GetMask("PlayingArea"); // Player1Area & Player2Area are on the layer PlayingArea

        if (Physics.Raycast(ray, out floorHit, 100, floorMask)) // Check if ray intersects playingFieldLayer
        {
            return floorHit.point; // get coordinates of intersection
        }
        else
        {
            return new Vector3(); // No intersections
        }
    }
}

