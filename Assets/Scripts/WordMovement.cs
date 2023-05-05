using UnityEngine;

public class WordMovement : MonoBehaviour
{
    public float speed = 3f;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Move the word down
        rectTransform.anchoredPosition -= new Vector2(0, speed * Time.deltaTime);
    }
}
