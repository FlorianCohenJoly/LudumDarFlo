using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject canvasEnd;


    /*   public void SetActiveCanvasEnd()
      {
          if (canvasEnd != null)
          {
              canvasEnd.SetActive(true);
          }
      } */

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
