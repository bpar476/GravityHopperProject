using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    [SerializeField]
    private float spinRate;

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, spinRate * Time.fixedDeltaTime));
    }
}
