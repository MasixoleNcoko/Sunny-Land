using UnityEngine;

public class BeginGame : MonoBehaviour
{
    public GameObject tutorial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorial.SetActive(true);
        Time.timeScale = 0;
    }

    public void Begin()
    {
        tutorial.SetActive(false);
        Time.timeScale = 1;
    }
}
