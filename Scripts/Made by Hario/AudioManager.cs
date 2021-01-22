using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audiomanager by HarioGames
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource _audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audioClip, bool playOneShot)
    {
        if (playOneShot)
        {
            _audioSource.PlayOneShot(audioClip);
        }
        else
        {
            _audioSource.Stop();
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }
}

