using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour {

    public static GlobalSettings instance;

    public bool isServer = false;
    public string hostAddress;

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
