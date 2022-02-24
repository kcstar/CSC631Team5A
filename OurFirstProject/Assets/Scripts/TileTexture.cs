using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTexture : MonoBehaviour
{
    Vector2 textureScale = new Vector2(0.5f, 0.5f);

    // Update is called once per frame
    void Update()
    {
        float scaleX = transform.localScale.x;
        float scaleY = transform.localScale.y;
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(scaleX, scaleY) * textureScale;
    }
}
