using UnityEngine;
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
        Debug.Log(GameObject.FindGameObjectWithTag("Player"));
        Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>());
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().SelectSpell(skillIndex);
    }
}
