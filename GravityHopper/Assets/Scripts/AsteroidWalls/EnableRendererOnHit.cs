using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRendererOnHit : MonoBehaviour
{
    [SerializeField]
    private float period;
    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        myRenderer.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            myRenderer.enabled = true;
            StartCoroutine(DisableRendererAfterPeriod());
        }
    }

    private IEnumerator DisableRendererAfterPeriod()
    {
        yield return new WaitForSecondsRealtime(period);
        myRenderer.enabled = false;
    }
}
