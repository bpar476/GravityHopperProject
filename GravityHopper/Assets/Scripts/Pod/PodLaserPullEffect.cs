using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodLaserPullEffect : MonoBehaviour
{
    [SerializeField]
    private Hovl_Laser laser;

    private PodInformation podInformation;

    private void Awake()
    {
        laser.enabled = false;
    }

    private void Start()
    {
        podInformation = PodInformation.Instance;
        podInformation.OnStartPulling += BeginPullEffectBetweenPodAndWell;
        podInformation.OnStopPulling += StopPullEffect;
    }

    private void BeginPullEffectBetweenPodAndWell(Transform well)
    {
        SetLaserEffectState(true);
        laser.target = well;
    }

    private void StopPullEffect(Transform well)
    {
        SetLaserEffectState(false);
    }

    private void SetLaserEffectState(bool state)
    {
        laser.enabled = state;
        laser.gameObject.SetActive(state);
    }


}
