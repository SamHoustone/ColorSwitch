using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private SpriteRenderer image;
    private Rigidbody2D rb;
    public float force;

    public Color cyan;
    public Color yellow;
    public Color magenta;
    public Color pink;

    public string currentColor;

    public GameObject won;
    public GameObject Lose;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        SetRandomColor();
    }
   public void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch(index)
        {
            case 0:
                currentColor = "Cyan";
                image.color = cyan;
                break;
            case 1:
                currentColor = "Yellow";
                image.color = yellow;
                break;
            case 2:
                currentColor = "Magenta";
                image.color = magenta;
                break;
            case 3:
                currentColor = "Pink";
                image.color = pink;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            rb.velocity = Vector2.up * force;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != currentColor && collision.tag != "Changer")
        {
            Debug.Log("FUfasdsdsdsdsdsdsdsdsdCK");
            Lose.SetActive(true);
        }
        if (collision.tag == "Changer")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }
        else
        {
        }
        if (collision.tag == "End")
        {
            won.SetActive(true);
        }
        if (collision.tag == "GO")
        {
            Lose.SetActive(true);
        }
    }

}
