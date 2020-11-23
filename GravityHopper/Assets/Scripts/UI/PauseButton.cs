using UnityEngine;

public class PauseButton : MonoBehaviour
{

    private void Start()
    {
        PauseManager.Instance.OnPause += () => Debug.Log("Pause");
    }

    public void Pause()
    {
        PauseManager.Instance.Pause();
    }
}
