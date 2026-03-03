using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject volumeSettingsPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameDescriptionPanel;

     void Start()
    {
        mainMenuPanel.SetActive(true);
        volumeSettingsPanel.SetActive(false);
        gameDescriptionPanel.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenVolumeSettings()
    {
        volumeSettingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void OpenGameDescription()
    {
        mainMenuPanel.SetActive(false);
        gameDescriptionPanel.SetActive(true);

    }
}
