using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTests : MonoBehaviour {

    [HideInInspector]public Texture2D tex;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetTexture(Texture2D texture)
    {
        spriteRenderer.sprite = createSprite(texture);
    }

    Sprite createSprite(Texture2D tex)
    {
        return Sprite.Create(tex,
        new Rect(0f, 0f, tex.width, tex.height),
        new Vector2(.5f, .5f),
        tex.height);
    }

}
