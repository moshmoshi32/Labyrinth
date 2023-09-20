using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerBallPrefab;
    [SerializeField] private Transform playerStart;
    [SerializeField] private MovePlatform labyrinth;

    private int currentLives;
    public int Lives
    {
        get => currentLives;
        set => currentLives = value;
    }

    private int currentScore;
    public int Score
    {
        get => currentScore;
        set => currentScore = value;
    }

    private GameObject playerBall;
    // Start is called before the first frame update
    void Start()
    {
        playerBall = Instantiate(playerBallPrefab, playerStart.position, playerStart.rotation);
        playerBall.GetComponent<Rigidbody>().sleepThreshold = 0;
        currentLives = 3;
        Time.timeScale = 1;
        UIManager.UpdateUILives?.Invoke(currentLives, currentScore);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartPlayer(Transform player)
    {
        if (Lives <= 0)
        {
            UIManager.ToggleLosePanel?.Invoke(true);
            Time.timeScale = 0;
            return;
        }
        player.transform.position = playerStart.transform.position;
        labyrinth.ResetPlatform();
        UIManager.UpdateUILives?.Invoke(currentLives, currentScore);
    }
}
