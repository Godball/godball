using UnityEngine;
using System.Collections;

public class TestPlayer : MonoBehaviour {

    public Object prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            // Spawn prefab
            Object wall = Instantiate(prefab, new Vector3(5.0f, -0.6f, 0.0f), Quaternion.identity);
        }
    }
}
