using UnityEngine;
using System.Collections;


/* Functions that do stuff when a button is pressed
 * buttons can have functions attached to them in the inspector.
 */
public class MenuHandeler : MonoBehaviour {

	public Canvas mainMenu;
	public Canvas heroSelection;
	public Canvas options;

	void Awake()
	{
		mainMenu.enabled = true;
		heroSelection.enabled = false;
		options.enabled = false;
	}

	// Main menu Functions for Buttons
	public void PlayButton()
	{
		mainMenu.enabled = false;
		heroSelection.enabled = true;
	}

	public void OptionsButton()
	{
		options.enabled = true;
		mainMenu.enabled = false;
	}

	public void QuitButton()
	{

	}

	//Hero Selection Functions for Buttons
	public void SlectThor()
	{
		Application.LoadLevel ("TestLevel");
	}

	public void SelectZeus()
	{
		Application.LoadLevel ("TestLevel");
	}


	// Function used in both Options and Hero Selection
	public void BackToMainMenu()
	{
		mainMenu.enabled = true;
		heroSelection.enabled = false;
		options.enabled = false;
	}
}
