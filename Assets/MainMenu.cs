using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsWindow;
    public void ALATTAQUE()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void SETTINGS()
    {
        settingsWindow.SetActive(true);

    }

    public void CloseSettingsWindow()
    { settingsWindow.SetActive(false); }
    public void CAPITULATION()
    {
        Application.Quit();
    }
}
