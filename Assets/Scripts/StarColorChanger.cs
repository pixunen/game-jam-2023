using System.Collections;
using UnityEngine;

public class StarColorChanger : MonoBehaviour
{
    public float colorChangeInterval = 1.0f;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value, 1.0f);
            yield return new WaitForSeconds(colorChangeInterval);
        }
    }
}
