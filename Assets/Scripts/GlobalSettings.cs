using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour {

    public static GlobalSettings instance;

    public bool isServer = false;
    public string hostAddress;

    public Skill skill0;
    public Skill skill1;
    public Skill skill2;
    public Skill skill3;
    public Skill skill4;

	// Use this for initialization
	void Start () {

	}

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
