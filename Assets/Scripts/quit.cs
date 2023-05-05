using UnityEngine;

public class quit : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void OnButtonClick()
    {
        Quit();
    }
}
