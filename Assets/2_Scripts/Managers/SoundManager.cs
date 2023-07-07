using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource UISelect;
    public AudioSource HitSound;
    public AudioSource MoneyCollect;
    public AudioSource SirenSound;

    public AudioSource MenuMusic;
    public AudioSource GameMusic;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        Instance = this;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main Menu")
        {
            MenuMusic.Play();
            GameMusic.Stop();
        }
        else if (scene.name == "City Map")
        {
            MenuMusic.Stop();
            GameMusic.Play();
        }
    }

    public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }
}
