using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private Camera mainCamera;
    public Transform player;
    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, -10f);
        }
        
    }
}
