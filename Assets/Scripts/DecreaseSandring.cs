using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSandring : MonoBehaviour
{
    public ParticleSystem sandRing1, sandRing2, sandRing3;
    public ParticleSystem.EmissionModule sandEmission1, sandEmission2, sandEmission3;

    private bool exitRing;

    private float min = 0f;
    private float max = 5000f;

    void Start()
    {
        sandEmission1 = sandRing1.emission;
        sandEmission2 = sandRing2.emission;
        sandEmission3 = sandRing3.emission;
    }
    void Update()
    {
        if (exitRing)
        {
            sandEmission1.enabled = true;
            sandEmission2.enabled = true;
            sandEmission3.enabled = true;
            sandEmission1.rateOverTime = max;
            sandEmission2.rateOverTime = max;
            sandEmission3.rateOverTime = max;
        }
        else
        {
            sandEmission1.enabled = false;
            sandEmission2.enabled = false;
            sandEmission3.enabled = false;
            sandEmission1.rateOverTime = min;
            sandEmission2.rateOverTime = min;
            sandEmission3.rateOverTime = min;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            exitRing = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            exitRing = true;
        }
    }
}
