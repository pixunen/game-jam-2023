using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Button[] sceneButtons;

    private void Start()
    {
        for (int i = 0; i < sceneButtons.Length; i++)
        {
            int index = i + 1;
            sceneButtons[i].onClick.AddListener(() => ChangeScene(index));
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
