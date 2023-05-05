using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject wordPrefab;
    public Transform enemySpawnPoint;
    public Transform wordsContainer;
    public float spawnRate = 2f;
    public int maxWords = 3;
    public float speedUpFactor = 0.95f;
    public float speedUpInterval = 5f;
    public TextMeshProUGUI scoreText;

    private float nextSpeedUpTime;
    private TMP_Text currentWord;
    private int currentWordIndex;
    private GameObject currentEnemy;
    private List<TMP_Text> wordsQueue = new List<TMP_Text>();
    private float timeToNextSpawn;
    private int score = 0;
    private Sprite[] sprites;
    private int currentIndex = 0;

    private void Start()
    {
        timeToNextSpawn = spawnRate;
        nextSpeedUpTime = Time.time + speedUpInterval;
        sprites = Resources.LoadAll<Sprite>("monsters");
    }

    private void Update()
    {
        timeToNextSpawn -= Time.deltaTime;

        if (timeToNextSpawn <= 0)
        {
            SpawnWordAndEnemy();
            timeToNextSpawn = spawnRate;
        }

        SpeedUpSpawning();

        // Update the score text
        scoreText.text = $"Score: {score}";
    }

    private void SpeedUpSpawning()
    {
        if (Time.time >= nextSpeedUpTime)
        {
            spawnRate *= speedUpFactor;
            //spawnRate = Mathf.Max(spawnRate, 0.1f); // Set a minimum spawn rate to prevent it from becoming too fast
            nextSpeedUpTime = Time.time + speedUpInterval;
        }
    }

    private void SpawnWordAndEnemy()
    {
        if (wordsQueue.Count < maxWords)
        {
            // Generate a word with increasing complexity
            string word = WordGenerator.GenerateWord();

            // Spawn a Word prefab and set its text
            GameObject wordObject = Instantiate(wordPrefab, wordsContainer);
            TMP_Text wordText = wordObject.GetComponent<TMP_Text>();
            wordText.text = word;

            // Set the Word prefab position and rotation
            RectTransform wordRectTransform = wordObject.GetComponent<RectTransform>();
            wordRectTransform.pivot = new Vector2(0.5f, 0.5f);

            float randomX = Random.Range(0.1f, 0.9f);
            wordRectTransform.anchoredPosition = new Vector2(randomX * wordsContainer.GetComponent<RectTransform>().rect.width, -5);

            float randomRotation = Random.Range(-5f, 5f);
            wordRectTransform.rotation = Quaternion.Euler(0, 0, randomRotation);

            // Enqueue the Word prefab
            wordsQueue.Add(wordText);

            // Spawn an enemy and associate it with the Word prefab
            GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
            // Assign a random sprite to the enemy
            SpriteRenderer enemySpriteRenderer = enemy.GetComponent<SpriteRenderer>();
            int randomIndex = currentIndex;
            currentIndex++;
            if (currentIndex >= sprites.Length)
            {
                ShuffleSprites();
                currentIndex = 0;
            }
            enemySpriteRenderer.sprite = sprites[randomIndex];
            enemy.GetComponent<EnemyMovement>().associatedWordObject = wordObject;
            wordObject.GetComponent<WordInfo>().associatedEnemy = enemy;
        }
    }

    public void HandleInput(string input)
    {
        if (currentWord == null)
        {
            foreach (TMP_Text word in wordsQueue)
            {
                if (word.text.StartsWith(input.ToUpper()))
                {
                    currentWord = word;
                    currentWordIndex = 1;
                    currentEnemy = word.GetComponent<WordInfo>().associatedEnemy;
                    word.text = $"<color=#808080>{word.text[..currentWordIndex]}</color>{word.text.Substring(currentWordIndex)}";
                    break;
                }
            }
        }
        else
        {
            string wordText = currentWord.text.Replace("<color=#808080>", "").Replace("</color>", "");
            if (wordText[currentWordIndex..].StartsWith(input.ToUpper()))
            {
                currentWordIndex++;

                if (currentWordIndex < wordText.Length)
                {
                    currentWord.text = $"<color=#808080>{wordText[..currentWordIndex]}</color>{wordText[currentWordIndex..]}";
                }
                else
                {
                    RemoveWord();
                }
            }
            else
            {
                ResetCurrentWord();
            }
        }
    }
    private void ResetCurrentWord()
    {
        if (currentWord != null)
        {
            currentWord.text = currentWord.text.Replace("<color=#808080>", "").Replace("</color>", "");
            currentWord = null;
            currentEnemy = null;
            currentWordIndex = 0;
        }
    }
    public void RemoveWord()
    {
        if (currentEnemy != null)
        {
            Destroy(currentEnemy);
        }
        Destroy(currentWord.gameObject);
        wordsQueue.Remove(currentWord);
        ResetCurrentWord();

        // Increment the score by 1
        score++;
    }

    private void ShuffleSprites()
    {
        for (int i = sprites.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Sprite temp = sprites[i];
            sprites[i] = sprites[randomIndex];
            sprites[randomIndex] = temp;
        }
    }
}