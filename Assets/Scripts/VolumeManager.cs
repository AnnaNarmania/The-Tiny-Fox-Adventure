using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider vfxSlider;
    [SerializeField] private GameObject mainMenuPanel;


    void Start()
{
    if (musicSlider != null)
    {
        musicSlider.value = SoundManager.Instance.BackgroundMusicVolume;
        musicSlider.onValueChanged.AddListener(OnMusicChanged);
    }

    if (vfxSlider != null)
    {
        vfxSlider.value = SoundManager.Instance.SFXVolume;
        vfxSlider.onValueChanged.AddListener(OnVFXChanged);
    }
}

    void OnMusicChanged(float value)
{
    SoundManager.Instance.SetBackgroundMusicVolume(value);
}

void OnVFXChanged(float value)
{
    SoundManager.Instance.SetSFXVolume(value);
}

    public void CloseVolumeSettings()
    {
        gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
