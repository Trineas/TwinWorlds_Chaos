using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprints : MonoBehaviour
{
    public float Lifetime = 2.0f;
    public float fadeSpeed;

    private float mark;

    private Material mat;

    public void Start()
    {
        mark = Time.time;
        mat = GetComponentInChildren<Renderer>().material;
    }

    public void Update()
    {
        float ElapsedTime = Time.time - mark;

        if (ElapsedTime != 0)
        {
            SetAlpha((Time.time - Lifetime) * fadeSpeed);
            if (ElapsedTime > Lifetime)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void SetAlpha(float alpha)
    {
        Color color = mat.color;
        color.a = Mathf.Clamp(alpha, 0, 1);
        mat.color = color;
    }
}