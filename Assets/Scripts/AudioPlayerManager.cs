using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    public AudioSource music;
    public static AudioPlayerManager instance = null;

    private void Awake ()
    {
        if (instance == null)
          { 
               instance = this;
               DontDestroyOnLoad(gameObject);
               return;
          }
          if (instance == this) return; 
          Destroy(gameObject);
    }

    private void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
    }

    private void Update ()
    {
        if (!music.isPlaying)
        {
            music.Play();
        }
    }
}

