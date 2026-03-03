using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource _backgroundMusicAudioSource;
    [SerializeField] private AudioSource _sfxAudioSource;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _hurtSound;
    [SerializeField] private AudioClip _collectSound;
    [SerializeField] private AudioClip _healSound;
    [SerializeField] private AudioClip _GameOverSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _enemyDeathSound;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

 

    private void PlayBackgroundMusic()
    {
        if(!_backgroundMusicAudioSource.isPlaying)
        {
            _backgroundMusicAudioSource.Play();
        }
    }

    public void PlayJumpSound()
    {
        _sfxAudioSource.PlayOneShot(_jumpSound);
    }

    public void PlayHurtSound()
    {
        _sfxAudioSource.PlayOneShot(_hurtSound);
    }

    public void PlayCollectSound()
    {
        _sfxAudioSource.PlayOneShot(_collectSound);
    }

    public void PlayHealSound()
    {
        _sfxAudioSource.PlayOneShot(_healSound);
    }

    public void PlayGameOverSound()
    {
        _sfxAudioSource.PlayOneShot(_GameOverSound);
    }

    public void PlayWinSound()
    {
        _sfxAudioSource.PlayOneShot(_winSound);
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        _backgroundMusicAudioSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        _sfxAudioSource.volume = volume;
    }

    public void PlayShootSound()
    {
        _sfxAudioSource.PlayOneShot(_shootSound);
    }

    public void PlayEnemyDeathSound()
    {
        _sfxAudioSource.PlayOneShot(_enemyDeathSound);
    }

    public float BackgroundMusicVolume => _backgroundMusicAudioSource.volume;
    public float SFXVolume => _sfxAudioSource.volume;

}
