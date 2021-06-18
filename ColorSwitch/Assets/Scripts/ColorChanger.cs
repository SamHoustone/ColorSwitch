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
    public void GetColor(Color color)
    {
       transform.GetComponent<SpriteRenderer>().color = color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.audioManager.ColorChangePlay();
        gameManager.number++;
        gameManager.Score++;
        gameManager.AssignColorOnRuntime();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameManager.uIManager.UpdateScore();

    }
    private void Update()
    {
       if(gameManager.number == 10)
        {
            Debug.Log("more");
           gameManager.number = 0;
           gameManager.More();
        }
    }
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
