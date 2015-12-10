using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Initialization : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NetworkManager nm = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        if (GlobalSettings.instance.isServer)
        {
            nm.networkAddress = Network.player.ipAddress;
            nm.StartServer();
        }
        else
        {
            //nm.networkAddress = GlobalSettings.instance.hostAddress;
            nm.networkAddress = Network.player.ipAddress;
            nm.StartClient();
        }
	}
}
