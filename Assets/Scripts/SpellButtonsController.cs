using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellButtonsController : MonoBehaviour 
{
	void Start()
	{
	}

    public void SelectSpell(int skillIndex)
    {
        //Debug.Log(GameObject.FindGameObjectWithTag("Player"));
        //Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>());
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);
        System.Collections.Generic.List<PlayerController> pc = GameObject.Find("NetworkManager").GetComponent<NetworkManager>().client.connection.playerControllers;
        foreach (PlayerController player in pc)
        {
            Debug.Log("Player" + player.playerControllerId + " is " + player.unetView.isLocalPlayer);
            player.gameObject.GetComponent<PlayerScript>().SelectSpell(skillIndex);
        }
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().SelectSpell(skillIndex);
    }
}
