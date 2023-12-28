using UnityEngine;

public class AsteroidRenderer : MonoBehaviour
{
    [SerializeField] private Sprite[] asteroidSprites;

    private void Start()
    {
        int randomIndex = Random.Range(0, asteroidSprites.Length);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = asteroidSprites[randomIndex];
    }
}