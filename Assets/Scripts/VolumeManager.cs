using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider vfxSlider;
    [SerializeField] private GameObject mainMenuPanel;

    public SoundManager soundManager;

    void Start()
    {
        musicSlider.onValueChanged.AddListener(OnMusicChanged);
        vfxSlider.onValueChanged.AddListener(OnVFXChanged);
    }

    void OnMusicChanged(float value)
    {
        soundManager.SetBackgroundMusicVolume(value);
    }

    void OnVFXChanged(float value)
    {
        soundManager.SetSFXVolume(value);
    }

    public void CloseVolumeSettings()
    {
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
