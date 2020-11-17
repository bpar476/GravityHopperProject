using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryEffect : MonoBehaviour
{
    /// <summary>
    /// Time in seconds after which the scene will be reloaded when the
    /// victory effect is called
    /// </summary>
    [SerializeField]
    private float reloadPeriod;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // TODO: Refactor this to use C# Event system
    public void OnVictory()
    {
        StartCoroutine(ReloadSceneAfterPeriod());

        // FIXME: Turn down main theme audio
        audioSource.Play();
    }

    private IEnumerator ReloadSceneAfterPeriod()
    {
        yield return new WaitForSeconds(reloadPeriod);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
