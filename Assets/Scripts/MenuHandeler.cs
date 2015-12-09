using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* Functions that do stuff when a button is pressed
 * buttons can have functions attached to them in the inspector.
 */
public class MenuHandeler : MonoBehaviour {

	public Canvas mainMenu;
	public Canvas heroSelection;
	public Canvas options;
    public Canvas modeScreen; // Client or host

	public Button thorButton;
	public Button zeusButton;
	public Image thorSelectColor;
	public Image zeusSelectColor;
	public Button readyButton;

	private bool thorSelected;
	private bool zeusSelected;
	private bool readyButtonActive;

	private Color selectedColor;
	private Color disabledColor;

	void Start()
	{
        modeScreen.enabled = true;
		mainMenu.enabled = false;
		heroSelection.enabled = false;
		options.enabled = false;

		thorSelected = false;
		zeusSelected = false;

		readyButtonActive = false;
		readyButton.interactable = false;

		selectedColor = Color.green;
		selectedColor.a = 0.5f;

		disabledColor = Color.clear;
		disabledColor.a = 0f;

		thorSelectColor.color = disabledColor;
		zeusSelectColor.color = disabledColor;
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

    public void ClientButton()
    {
        mainMenu.enabled = true;

        GlobalSettings.instance.hostAddress = GameObject.Find("IPInput").GetComponent<InputField>().text;
    }

    public void HostButton()
    {
        GlobalSettings.instance.isServer = true;
        ReadyButton();
    }

	public void QuitButton()
	{
		Application.Quit ();
	}

	//Hero Selection Functions for Buttons
	public void SlectThor()
	{
		thorSelected = true;
		zeusSelected = false;
		thorSelectColor.color = selectedColor;
		zeusSelectColor.color = disabledColor;

		if(!readyButtonActive)
		{
			readyButtonActive = true;
			readyButton.interactable = true;
		}
	}

	public void SelectZeus()
	{
		thorSelected = false;
		zeusSelected = true;
		zeusSelectColor.color = selectedColor;
		thorSelectColor.color = disabledColor;

		if(!readyButtonActive)
		{
			readyButtonActive = true;
			readyButton.interactable = true;
		}
	}

	public void ReadyButton()
	{

		Application.LoadLevel ("TestLevel");
	}

	// Function used in both Options and Hero Selection
	public void BackToMainMenu()
	{
		thorSelected = true;
		zeusSelected = false;
		thorSelectColor.color = disabledColor;
		zeusSelectColor.color = disabledColor;

		mainMenu.enabled = true;
		heroSelection.enabled = false;
		options.enabled = false;

		readyButtonActive = false;
		readyButton.interactable = false;
	}
}
