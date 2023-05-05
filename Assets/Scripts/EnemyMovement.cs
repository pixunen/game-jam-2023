using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public GameObject player;
    public GameObject associatedWordObject;
    public GameObject gameOverTextPrefab;
    public GameObject gameOverButtonPrefab;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // End the game
            GameOver();
        }
    }

    private void GameOver()
    {
        // Implement your game over logic here
        Time.timeScale = 0f; // Pause the game

        // Find the canvas in the scene
        GameObject canvas = GameObject.FindWithTag("Canvas");

        // Instantiate the "GAME OVER" text prefab as a child of the canvas
        GameObject gameOverTextObject = Instantiate(gameOverTextPrefab, canvas.transform);
        gameOverTextObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        GameObject gameOverButtonObject = Instantiate(gameOverButtonPrefab, canvas.transform);
        gameOverButtonObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -70);
    }
}