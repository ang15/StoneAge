using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioOption : MonoBehaviour
{
    public AudioSource audios;
    public float volume = 1f;
    private void Start()
    {
        volume = 0.5f;

    }
    private void Update()
    {
        audios.volume = volume;

    }

}

