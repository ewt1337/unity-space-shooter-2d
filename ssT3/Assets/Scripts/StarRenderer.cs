using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRenderer : MonoBehaviour
{
    [SerializeField] private Sprite[] starSprites;

    private void Start()
    {
        int randomIndex = Random.Range(0, starSprites.Length);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = starSprites[randomIndex];
    }
}