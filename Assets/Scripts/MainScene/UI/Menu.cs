using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    SpawnManager spawnManager;

    [SerializeField]
    GameObject tutorialMenu;
    [SerializeField]
    GameObject tutorialMsg1;
    [SerializeField]
    GameObject tutorialMsg2;
    [SerializeField]
    GameObject tutorialMsg3;
    [SerializeField]
    GameObject tutorialMsg4;

    public void StartGame()
    {
        CameraTransition cameraTransition = Camera.main.gameObject.GetComponent<CameraTransition>();

        // Spawn player at a random spawn point
        spawnManager.SpawnPlayer(player);

        // Find light manager in the scene
        GameObject lightManager = GameObject.FindGameObjectWithTag("LightManager");

        // Load the tutorial page
        StartCoroutine(DisplayTutorial(cameraTransition, lightManager));

        // Disable the main menu
        GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCredits(GameObject creditsMenu)
    {
        GameObject.FindGameObjectWithTag("MainMenu").SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CloseCredits(GameObject mainMenu)
    {
        mainMenu.SetActive(true);
        GameObject.FindGameObjectWithTag("CreditsMenu").SetActive(false);
    }

    private IEnumerator DisplayTutorial(CameraTransition cameraTransition, GameObject lightManager)
    {
        // Enable the tutorial menu with all text hidden
        tutorialMenu.SetActive(true);
        tutorialMsg1.SetActive(false);
        tutorialMsg2.SetActive(false);
        tutorialMsg3.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        tutorialMsg1.SetActive(true);

        yield return new WaitForSeconds(2f);
        tutorialMsg2.SetActive(true);

        yield return new WaitForSeconds(2f);
        tutorialMsg3.SetActive(true);

        yield return new WaitForSeconds(2f);
        tutorialMsg1.SetActive(false);
        tutorialMsg2.SetActive(false);
        tutorialMsg3.SetActive(false);
        tutorialMsg4.SetActive(true);

        yield return new WaitForSeconds(2f);

        // Disable the tutorial messages
        tutorialMenu.SetActive(false);

        // Start the game
        StartCoroutine(cameraTransition.Transition(player, lightManager));
    }

}