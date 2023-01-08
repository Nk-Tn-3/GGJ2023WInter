using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource music_source, sfx_source;

    public void PlayerMusic(AudioClip music)
    {
        if (music)
        {
            music_source.clip = music;
            music_source.Play();
        }
    }

    public void PlaySFX(AudioClip sfx)
    {
        if(sfx)
        {
            sfx_source.PlayOneShot(sfx);
        }
    }
}
