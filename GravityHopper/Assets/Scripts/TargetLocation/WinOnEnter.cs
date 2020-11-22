using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnEnter : MonoBehaviour
{

    /// <summary>
    /// Game object which when activated will show a visual effect
    /// that the challenge has been won
    /// </summary>
    [SerializeField]
    private VictoryEffect winEffect;

    /// <summary>
    /// Integer representing the number of the next level. e.g. if this is
    /// level 1, the value should be 2.
    /// </summary>
    [SerializeField]
    private int nextLevel;

    private void Awake()
    {
        winEffect.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == PodInformation.Instance.gameObject.name)
        {
            winEffect.gameObject.SetActive(true);
            winEffect.OnVictory();

            LevelProgression.Instance.UnlockLevel(nextLevel);
        }
    }
}
