using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject canvasController;
    public GameObject canvasCredits;
    public Button buttonStart;
    public Button buttonCredits;
    public Button buttonController;

    public Button buttonExit;

    public void StartGame()
    {
        // Load the main game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Playground");
    }

    public void ExitGame()
    {
        // Exit the application
        Application.Quit();
    }

    public void ShowCredits()
    {
        Debug.Log("Show Credits");
        canvasCredits.SetActive(true);
        canvasController.SetActive(false);

    }

    public void ShowController()
    {
        canvasController.SetActive(true);
        canvasCredits.SetActive(false);
    }

    public void BackToMainMenu()
    {
        canvasCredits.SetActive(false);
        canvasController.SetActive(false);
    }



}
