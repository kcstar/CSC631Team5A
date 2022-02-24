using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            MeshRenderer[] children = GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer renderer in children)
            {
                if (renderer.material.GetColor("_BaseColor").Equals(Color.red)) {
                    renderer.material.SetColor("_BaseColor", Color.green);
                } else {
                    renderer.material.SetColor("_BaseColor", Color.red);
                }
            }
        }
    }
}
