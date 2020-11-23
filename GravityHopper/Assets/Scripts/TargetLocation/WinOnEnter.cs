using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            // This is a workaround to use the "next level" part of this script for loading the end of
            // game scene. However, we don't want to unlock that scene as a "level" in the level select
            // UI so we skip the progression if the level number is greater than the number of levels
            if (nextLevel <= 5)
            {
                LevelProgression.Instance.UnlockLevel(nextLevel);
            }

            StartCoroutine(LoadNextLevelInTwoSeconds());
        }
    }

    private IEnumerator LoadNextLevelInTwoSeconds()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadSceneAsync(LevelToSceneIndex.ConvertToSceneIndex(nextLevel));
    }
}
