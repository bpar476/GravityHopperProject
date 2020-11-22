using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryEffect : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // TODO: Refactor this to use C# Event system
    public void OnVictory()
    {
        // FIXME: Turn down main theme audio
        audioSource.Play();
    }
}
