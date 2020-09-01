using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRenderOrderSystem : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = (int)(transform.parent.position.y * -100);
    }
}
