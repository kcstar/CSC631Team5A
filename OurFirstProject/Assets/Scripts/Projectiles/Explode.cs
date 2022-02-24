using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public Material material;
    public float fadeTime = 0.8f;
    private float elapsed = 0f;
    private Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        originalMaterial = renderer.material;
        renderer.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime;
        elapsed += t;
        if (elapsed / fadeTime > 1)
        {
            Destroy(this);

            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.SetFloat("_T", 1);

            renderer.material = originalMaterial;

        }
        else
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.SetFloat("_T", elapsed / fadeTime);
        }
    }
}
