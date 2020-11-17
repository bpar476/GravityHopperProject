using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWellSFX : MonoBehaviour
{
    /// <summary>
    /// Amount to modulate the pitch of the sound effect by
    /// when player is pulled by well. Usually when being pulled in sequence wells should increase in pitch
    /// </summary>
    [SerializeField]
    [Range(0, 2)]
    private float sfxPitchModulation = 0f;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 1 + sfxPitchModulation;
    }

    public void PlayPullSFX()
    {
        audioSource.Play();
    }
}
