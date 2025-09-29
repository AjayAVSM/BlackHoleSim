using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject slidersUI;
    public Image settingsButtonIcon;
    public Image encyclopaediaButtonIcon;
    public Image sliderButtonIcon;
    public Color activeColor = Color.yellow;
    public Color normalColor = Color.white;
    public void OnSettingsPress()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        settingsButtonIcon.color = activeColor;
    }
    public void OnResumePress()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        settingsButtonIcon.color = normalColor;
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
    public void OnSliderPress()
    {
        if (slidersUI.activeSelf)
        {
            slidersUI.SetActive(false);
            sliderButtonIcon.color = normalColor;
        }
        else
        {
            slidersUI.SetActive(true);
            sliderButtonIcon.color = activeColor;
        }
        
    }

}
