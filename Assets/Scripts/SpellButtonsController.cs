using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellButtonsController : MonoBehaviour 
{
    public bool[] spells;
    private Button[] button;
    private int numberOfSpells;

	void Awake()
	{
		button = GetComponentsInChildren<Button> ();
        numberOfSpells = button.Length;
        spells = new bool[numberOfSpells];

        // set all spells to false
        for(int i = 0; i<numberOfSpells; i++)
        {
            spells[i] = false;
        }
	}
	void Start()
	{
		foreach (Button b in button) 
		{
			b.image.color = Color.white;
		}
	}

	public void Spells(int whatSpell)
	{
        for(int i = 0; i < numberOfSpells; i++) // go through all spells
        {
            if(whatSpell == i && spells[i] == false) // find the one clicked on, and if it is not the one active atm
            {
                    for(int j = 0; j<button.Length; j++) // go through all buttons
                    {
                        // set active spell green, all else white
                        if (j == i)
                        {
                            spells[j] = true;
                            button[j].image.color = Color.green;
                            
                        }
                        else {
                            spells[j] = false;
                            button[j].image.color = Color.white;
                            
                        }

                    }
                }
        }
    }
}
