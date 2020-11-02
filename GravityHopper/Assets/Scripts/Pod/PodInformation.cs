using System;
using UnityEngine;

public class PodInformation : MonoBehaviour
{
    public static PodInformation Instance { get; private set; }

    public event Action OnStopPulling;
    public event Action OnStartPulling;

    public bool IsBeingPulled
    {
        get
        {
            return isBeingPulled;
        }
        set
        {
            if (value && !isBeingPulled)
            {
                OnStartPulling?.Invoke();
            }
            else if (!value && isBeingPulled)
            {
                OnStopPulling?.Invoke();
            }
            isBeingPulled = value;
        }
    }

    private bool isBeingPulled = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
