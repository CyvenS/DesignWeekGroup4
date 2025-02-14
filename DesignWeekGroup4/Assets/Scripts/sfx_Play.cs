using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfx_Play : MonoBehaviour
{
    private AudioSource audioClip;
    void Start()
    {
        GameObject.DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        audioClip = GetComponent<AudioSource>();
    }

    private void PlaySFX()
    {
        // call this to play the sound
        audioClip.Play();
    }
}
