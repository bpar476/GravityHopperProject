﻿using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void Pause()
    {
        PauseManager.Instance.Pause();
    }
}
