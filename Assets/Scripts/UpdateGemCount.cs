using System;
using TMPro;
using UnityEngine;

public class UpdateGemCount : MonoBehaviour
{
    public int gemCount = 0;
    public int gemCountMax = 5;

    public TextMeshProUGUI gemNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gemNumber == null)
        {
            Debug.LogError("UpdateGemCount script requires a TextMeshPro component on the same GameObject.");
            return;
        }
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateDisplay()
    {
        if(gemNumber != null)
        {
            gemNumber.text = $"Gems: {gemCount}";
        }
    }

    private void UpdateWinDisplay()
    {
        if(gemNumber != null)
        {
            gemNumber.text = "You Win!";
        }
    }

    public void AddGem(int amount)
    {
        if (gemCount < gemCountMax)
        {
            gemCount += amount;
            UpdateDisplay();
            Debug.Log("Gem Collected");
        }
        else if (gemCount >= gemCountMax)
        {
            UpdateWinDisplay();
            Debug.Log("You Win!");
        }
    }

}
