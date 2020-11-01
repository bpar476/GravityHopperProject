using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodInformation : MonoBehaviour
{
    public static PodInformation Instance { get; private set; }

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
