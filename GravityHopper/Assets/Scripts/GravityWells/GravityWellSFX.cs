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

    /// <summary>
    /// Sound effect to play when pod starts being pulled by gravity well
    /// </summary>
    [SerializeField]
    private AudioClip pullSound;
    [Range(0, 1)]
    [SerializeField]
    private float pullSoundVolume;

    /// <summary>
    /// Sound effect to play when pod tries to grab well but is out of range
    /// </summary>
    [SerializeField]
    private AudioClip outOfRangeSound;
    [Range(0, 1)]
    [SerializeField]
    private float outOfRangeSoundVolume;


    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 1 + sfxPitchModulation;
    }

    public void PlayPullSFX()
    {
        audioSource.clip = pullSound;
        audioSource.volume = pullSoundVolume;
        audioSource.Play();
    }

    public void PlayOutOfRangeSFX()
    {
        audioSource.clip = outOfRangeSound;
        audioSource.volume = outOfRangeSoundVolume;
        audioSource.Play();
    }
}
