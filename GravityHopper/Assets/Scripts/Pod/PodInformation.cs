using System;
using UnityEngine;

public class PodInformation : MonoBehaviour
{
    public static PodInformation Instance { get; private set; }

    public bool IsBeingPulled { get { return isBeingPulled; } }

    public event Action<Transform> OnStopPulling;
    public event Action<Transform> OnStartPulling;

    private GravityWell activeWell;

    private bool isBeingPulled = false;

    public void Grab(GravityWell well)
    {
        if (well == null)
        {
            return;
        }

        if (activeWell != null)
        {
            return;
        }

        // This would be a race condition if concurrent grabbing becomes allowed
        if (!isBeingPulled)
        {
            activeWell = well;
            OnStartPulling?.Invoke(well.transform);
            isBeingPulled = true;
        }
    }

    public void Release(GravityWell well)
    {
        if (well == null)
        {
            return;
        }
        if (activeWell != well)
        {
            return;
        }

        // This would be a race condition if concurrent grabbing becomes allowed
        if (isBeingPulled)
        {
            activeWell = null;
            isBeingPulled = false;
            OnStopPulling?.Invoke(well.transform);
        }
    }

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
