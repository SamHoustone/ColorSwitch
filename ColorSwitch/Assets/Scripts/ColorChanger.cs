using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.Score++;
        gameManager.AssignColorOnRuntime();
        Destroy(gameObject);
        gameManager.uIManager.UpdateScore();
    }
}
