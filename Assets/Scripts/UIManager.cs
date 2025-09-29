using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;
    public void OnSettingsPress()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnResumePress()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OnResetPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void OnQuitMenuPress()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void OnQuitAppPress()
    {
        Application.Quit();
    }
}
