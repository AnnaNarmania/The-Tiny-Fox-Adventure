using UnityEngine;

public class GameDescriptionUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
     public void CloseGameDescription()
    {
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
