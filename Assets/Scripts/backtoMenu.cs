using UnityEngine;
using UnityEngine.SceneManagement;

public class backtoMenu : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("game_start");
    }
    public void OnButtonClick()
    {
        Debug.Log("Button clicked!");
        ChangeScene();
    }
}
