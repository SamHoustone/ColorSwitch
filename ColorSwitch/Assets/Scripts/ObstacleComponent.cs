using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleComponent : MonoBehaviour
{
        public GameManager gameManager;
        public int speed;
        public SpriteRenderer[] colorsprites;
        private void Awake()
        {
        gameManager = FindObjectOfType<GameManager>();
        }
        public void AssignColor ()
        {
        for (int i = 0; i < colorsprites.Length; i++)
        {
            colorsprites[i].color = gameManager.colors[i];
        }
        }
        void Update()
        {
            transform.Rotate(0, 0, speed *Time.deltaTime);
        }
        public void SelfDestruct()
        {
            Destroy(gameObject,5f);
        }
}
