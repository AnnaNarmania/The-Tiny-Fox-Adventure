using UnityEngine;
using UnityEngine.SceneManagement; 

public class WinScript : MonoBehaviour
{
    
    public void Replay()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
