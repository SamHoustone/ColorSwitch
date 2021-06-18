using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Wonpanel;
    public GameObject LostPanel;
    public GameObject PlayPanel;
    public GameObject UiPanel;
    public Sprite[] bgImages;
    public TextMeshProUGUI ScoreText,ScoreTextWon,ScoreTextLost,HighScoreTextWon,HighScoreTextLost,HighScoreMain;
    private void Start()
    {
        HighScoreMain.text = "HIGHSCORE : " + gameManager.HighScore.ToString();
        PlayPanel.SetActive(true);
        Time.timeScale = 0;
        ScoreText.enabled = true;
        ScoreText.text = gameManager.Score.ToString();
        Wonpanel.SetActive(false);
        LostPanel.SetActive(false);
        int random = Random.Range(0,bgImages.Length);
        UiPanel.GetComponent<Image>().sprite = bgImages[random];
    }
    public void Restart()
    {
        Scene CurrentScene = SceneManager.GetActiveScene(); SceneManager.LoadScene(CurrentScene.name);
    }
    public void Won()
    {
        HighScoreTextWon.text = "HIGHSCORE : " + gameManager.HighScore.ToString();
        ScoreText.enabled = false;
        Wonpanel.SetActive(true);
    }
    public void Lost()
    {
        HighScoreTextLost.text = "HIGHSCORE : " + gameManager.HighScore.ToString();
        ScoreText.enabled = false;
        LostPanel.SetActive(true);
        gameManager.Lost();
    }
    public void UpdateScore()
    {
        ScoreTextWon.text = gameManager.Score.ToString();
        ScoreTextLost.text = gameManager.Score.ToString();
        ScoreText.text = gameManager.Score.ToString();
    }
    public void Play()
    {
        Time.timeScale = 1;
        PlayPanel.SetActive(false);
    }
}
