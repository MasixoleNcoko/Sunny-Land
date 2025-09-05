using UnityEngine;

public class ExitConfirmation : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject exitMenuPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenuPanel.SetActive(true);
        exitMenuPanel.SetActive(false);
    }

    public void Cancel()
    {
        mainMenuPanel.SetActive(false);
        exitMenuPanel.SetActive(true);
    }

    public void Return()
    {
        mainMenuPanel.SetActive(true);
        exitMenuPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
}
