using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    public AudioManager audioManager;
   public List<Color> colors = new List<Color>();
   public List<GameObject> Obstacles = new List<GameObject>();
    public GameObject colorChanger;
   public Transform ObstacleTransform;
   public Transform ColorChangerTransform;
   public List<GameObject> obstaclesList = new List<GameObject>();
   public List<GameObject> colorChangerList = new List<GameObject>();
   public int NoOfObstacles;
   public Player player;
   public int Score;
   public int HighScore;
   public int number;
   private int colorChangerCount;
   private int ObstacleCount;


   private void Start()
   {
       audioManager = FindObjectOfType<AudioManager>();
       HighScore = PlayerPrefs.GetInt("HighScore");
       Shuffle(colors);
       PopulateObstacles();
       PopulateColorChanger();
       AssignColor();
   }
   public void PopulateObstacles()
   {
      for (int i = 0; i < NoOfObstacles; i++)
      {
        int Range = Random.Range(0,Obstacles.Count);
        GameObject ObstaclesObj = Instantiate(Obstacles[Range]);
        obstaclesList.Add(ObstaclesObj);
        ObstaclesObj.transform.SetParent(ObstacleTransform);
        obstaclesList[i].transform.position += new Vector3(0,ObstacleCount*10,0);
        ObstacleCount++;
      }
   }
    public void PopulateColorChanger()
   {
      for (int j = 0; j < NoOfObstacles; j++)
      {
          GameObject colorChangerObj = Instantiate(colorChanger);
          colorChangerList.Add(colorChangerObj);
          colorChangerObj.transform.SetParent(ColorChangerTransform);
          colorChangerList[j].transform.position += new Vector3(-0.2f,colorChangerCount*10+5,0);
          colorChangerCount++;
      }
   }

   public void AssignColor()
   {
      Shuffle(colors);
      for (var i = 0; i < obstaclesList.Count; i++)
      {
        int SpeedRange = Random.Range(90,110); 
        int LeftOrRightDecider = Random.Range(0,2);

        if(LeftOrRightDecider == 0)
        {
            obstaclesList[i].GetComponent<ObstacleComponent>().speed = -SpeedRange;
        }
        else
        {
            obstaclesList[i].GetComponent<ObstacleComponent>().speed = SpeedRange;
        }     
        obstaclesList[i].GetComponent<ObstacleComponent>().AssignColor();
      } 
      player.currentColor = colors[0];
      player.ChangeColor();

      Shuffle(colors);
      colorChangerList[number].GetComponent<ColorChanger>().GetColor(colors[0]);   
   }
   public void AssignColorOnRuntime()
   {
       for (var i = 0; i < obstaclesList.Count; i++)
      {
        obstaclesList[i].GetComponent<ObstacleComponent>().AssignColor();    
      } 
      player.currentColor = colors[0];
      player.ChangeColor();

      Shuffle(colors);
      colorChangerList[number].GetComponent<ColorChanger>().GetColor(colors[0]);   
   }
   public void Shuffle(List<Color> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);

            Color temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;

        }
    }
    public void Lost()
    {
        audioManager.DeathPlay();
        HighScore = PlayerPrefs.GetInt("HighScore");
        if(HighScore < Score)
        {
            HighScore = Score;
        }
        PlayerPrefs.SetInt("HighScore",HighScore);
    }
     public void More()
    {
        for (int i = 0; i < obstaclesList.Count; i++)
        {
            obstaclesList[i].GetComponent<ObstacleComponent>().SelfDestruct();
            colorChangerList[i].GetComponent<ColorChanger>().SelfDestruct();
        }
        obstaclesList.Clear();
        colorChangerList.Clear();
        PopulateObstacles();
        PopulateColorChanger();
        AssignColor();
    }
}
