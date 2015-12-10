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
    public Button readyButton;

    public Image thorSelectColor; // Hilight Selection
	public Image zeusSelectColor;
    public Image thorSpellsInfo; // Show spells info
    public Image zeusSpellsInfo;
	
	private bool thorSelected;
	private bool zeusSelected;
	private bool readyButtonActive;

	//private Color selectedColor;
	//private Color disabledColor;

	void Start()
	{
        modeScreen.enabled = false;
		mainMenu.enabled = true;
		heroSelection.enabled = false;
		options.enabled = false;

		thorSelected = false;
		zeusSelected = false;

		readyButtonActive = false;
		readyButton.interactable = false;

        thorSelectColor.enabled = false;
        zeusSelectColor.enabled = false;

        thorSpellsInfo.enabled = false;
        zeusSpellsInfo.enabled = false;
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
        thorSpellsInfo.enabled = true;
        zeusSpellsInfo.enabled = false;
        thorSelectColor.enabled = true;
        zeusSelectColor.enabled = false;

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
        thorSpellsInfo.enabled = false;
        zeusSpellsInfo.enabled = true;
        thorSelectColor.enabled = false;
        zeusSelectColor.enabled = true;

        if (!readyButtonActive)
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
        thorSelectColor.enabled = false;
        zeusSelectColor.enabled = false;

		mainMenu.enabled = true;
		heroSelection.enabled = false;
		options.enabled = false;

        thorSpellsInfo.enabled = false;
        zeusSpellsInfo.enabled = false;

		readyButtonActive = false;
		readyButton.interactable = false;
	}
}
