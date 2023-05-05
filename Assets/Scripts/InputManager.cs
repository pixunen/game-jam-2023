using UnityEngine;

public class InputManager : MonoBehaviour
{
    public WordSpawner wordManager;

    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            // Convert the character to lowercase for case-insensitive input handling
            char lowerLetter = char.ToLower(letter);

            // Call the HandleInput() method with the typed letter
            wordManager.HandleInput(lowerLetter.ToString());
        }
    }
}
