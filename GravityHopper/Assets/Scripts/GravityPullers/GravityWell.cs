using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    private bool isBeingClicked = false;

    private void OnMouseDown()
    {
        Debug.Log("You clicked me");
        isBeingClicked = true;
    }

    private void OnMouseUp()
    {
        Debug.Log("You stopped clicking me");
        isBeingClicked = false;
    }

    private void Update()
    {
        if (isBeingClicked)
        {
            movePodTowardsWell();
        }
    }

    private void movePodTowardsWell()
    {
        var pod = PodInformation.Instance;
        var rb = pod.GetComponent<Rigidbody>();

        Vector3 directionFromPodToWell = transform.position - pod.transform.position;
        float distance = Vector3.Distance(transform.position, pod.transform.position);

        rb.velocity = directionFromPodToWell.normalized * distance * distance;
    }
}
