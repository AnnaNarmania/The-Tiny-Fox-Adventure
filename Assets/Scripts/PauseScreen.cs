using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;  
    [SerializeField] private Animator pauseButton;       

    private bool isPaused = false;

    
    public bool IsPaused => isPaused;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        
        isPaused = !isPaused;

        
        pauseMenuPanel.SetActive(isPaused);

        
        Time.timeScale = isPaused ? 0f : 1f;

        
        pauseButton.SetBool("IsPaused", isPaused);
    }

    
    public void Resume()
    {
        if (!isPaused) return;  

        isPaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        pauseButton.SetBool("IsPaused", false);
    }

    
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}