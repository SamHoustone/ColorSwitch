using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    public SpriteRenderer CubecolorMat;
    public Color currentColor;
    public GameManager gameManager;
    
    void Start()
    {
        CubecolorMat.color = currentColor;
        rb = GetComponentInChildren<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * force;
        }
    }
    public void ChangeColor()
    {
        CubecolorMat.color = currentColor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            if(collision.GetComponent<SpriteRenderer>().color != CubecolorMat.color)
           {
            gameManager.uIManager.Lost();
            gameManager.uIManager.UpdateScore();
           }
        }
        if(collision.CompareTag("End"))
        {
            gameManager.uIManager.Lost();
            Debug.Log("Died");
        }
    }

}
