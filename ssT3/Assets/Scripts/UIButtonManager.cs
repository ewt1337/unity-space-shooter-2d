using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    [SerializeField] private string MainMenuScene = "MainMenu";
    [SerializeField] private string playScene = "SpaceSurvival";

    public void GoPlayScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(playScene);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(playScene);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}