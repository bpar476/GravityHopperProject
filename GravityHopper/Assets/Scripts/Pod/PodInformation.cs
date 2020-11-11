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
            Debug.Log("Being grabbed by null well. This can't be good");
            return;
        }

        if (activeWell != null)
        {
            Debug.Log("Being pulled by two wells at once is not supported");
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
            Debug.Log("Being grabbed by null well. This can't be good");
            return;
        }
        if (activeWell != well)
        {
            Debug.Log("Can't be released by a well that isn't the active well");
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
