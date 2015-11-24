using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellButtonsController : MonoBehaviour 
{
	private bool spell1 = false;
	private bool spell2 = false;
	private bool spell3 = false;
	private bool spell4 = false;
	private Button[] button;

	void Awake()
	{
		button = GetComponentsInChildren<Button> ();
	}
	void Start()
	{
		foreach (Button b in button) 
		{
			b.image.color = Color.green;
		}
	}

	public void Spells(int whatSpell)
	{
		if(whatSpell == 1)
		{
			if(spell1 == false)
			{
				button[0].image.color = Color.red;
				spell1 = true;

				button[1].image.color = Color.green;
				spell2 = false;

				button[2].image.color = Color.green;
				spell3 = false;

				button[3].image.color = Color.green;
				spell4 = false;
			}
			//Debug.Log (whatSpell + " Was pressed");
		}
		if(whatSpell == 2)
		{
			if(spell2 == false)
			{
				spell2 = true;
				button[1].image.color = Color.red;

				button[0].image.color = Color.green;
				spell1 = false;

				button[2].image.color = Color.green;
				spell3 = false;

				button[3].image.color = Color.green;
				spell4 = false;
			}
			//Debug.Log (whatSpell + " Was pressed");
		}
		if(whatSpell == 3)
		{
			if(spell3 == false)
			{
				spell3 = true;
				button[2].image.color = Color.red;
				
				button[0].image.color = Color.green;
				spell1 = false;

				button[1].image.color = Color.green;
				spell2 = false;

				button[3].image.color = Color.green;
				spell4 = false;
			}
			//Debug.Log (whatSpell + " Was pressed");
		}
		if(whatSpell == 4)
		{
			if(spell4 == false)
			{
				spell4 = true;
				button[3].image.color = Color.red;

				button[0].image.color = Color.green;
				spell1 = false;

				button[1].image.color = Color.green;
				spell2 = false;

				button[2].image.color = Color.green;
				spell3 = false;
			}
			//Debug.Log (whatSpell + " Was pressed");
		}
	}
}
