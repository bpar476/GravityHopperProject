using System;

public class PauseManager : Singleton<PauseManager>
{

    public Action OnPause;

    public Action OnResume;

    private bool isPaused = false;

    protected override PauseManager Init()
    {
        return this;
    }

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            OnPause?.Invoke();
        }
    }

    public void Resume()
    {
        if (isPaused)
        {
            isPaused = false;
            OnResume?.Invoke();
        }
    }

}
