using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPodAtEndgame : MonoBehaviour
{
    [SerializeField]
    private Vector3 spin;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = spin;
    }

}
