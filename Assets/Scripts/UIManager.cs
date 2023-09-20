using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static Action<int, int> UpdateUILives;
    public static Action<bool> ToggleLosePanel;
    public static Action<string> screenUpdate;
    
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject losePanel;

    private void Awake()
    {
        UpdateUILives += UpdateLives;
        ToggleLosePanel += TogglePanel;
        losePanel.SetActive(false);
    }
    
    //private void 

    private void TogglePanel(bool value)
    {
        losePanel.SetActive(value);
    }
    private void UpdateLives(int lives, int score)
    {
        livesText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";
    }
}
