using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerController playerController;

    public GameObject defeatPanel;
    public GameObject victoryPanel;

    public TextMeshProUGUI tips;
    public string[] tipList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defeatPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    public void Fallen()
    {
        Debug.Log("Player has Fallen");
        if(playerHealth != null)
        {
            if (playerHealth.health <= 0)
            {
                defeatPanel.SetActive(true);
            //    Debug.Log("Panel active after Fallen: " + defeatPanel.activeSelf);
            //    Debug.Log("DefeatPanel inHierarchy: " + defeatPanel.activeInHierarchy);

                if (tips != null && tipList.Length > 0)
                {
                    int randomTip = Random.Range(0, tipList.Length);
                    tips.text = $"Tip:\n {tipList[randomTip]}";
                }
                Time.timeScale = 0;
            }
        }
    }

    public void Victory()
    {
        if(playerController != null)
        {
            if(playerController.gemCount >= playerController.gemCountMax)
            {
                victoryPanel.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("You are victorious");
            }
        }
    }

    public void Restart()
    {
        defeatPanel.SetActive(false);
        victoryPanel.SetActive(false);
        SceneManager.LoadScene("Main Scene");
        Debug.Log("Game Restarted");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Game exited");
    }
}
