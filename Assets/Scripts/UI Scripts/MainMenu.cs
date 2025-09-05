using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public ExitConfirmation exitConfirm;
    public void Play()
    {
        SceneManager.LoadScene("Main Scene");
        Debug.Log("Main game loaded");
    }

    public void Quit()
    {
        exitConfirm.Cancel();
    }
}
