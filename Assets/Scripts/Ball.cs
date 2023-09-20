using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }


    public void AddToScore(int score)
    {
        gameManager.Lives--;
        gameManager.Score += score;
        gameManager.RestartPlayer(transform);
        
        Debug.Log($"Score: {gameManager.Score} \nLives: {gameManager.Lives}");
        rb.velocity = Vector3.zero;
    }
}
