using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartSim()
    {
        SceneManager.LoadScene("VisualsMode");
    }
}
