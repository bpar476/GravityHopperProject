using UnityEngine;

public class ResumeButton : MonoBehaviour
{

    private void Start()
    {
        PauseManager.Instance.OnResume += () => Debug.Log("Resume");
    }

    public void Resume()
    {
        PauseManager.Instance.Resume();
    }
}
