using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject flappyWave,GameOverPanal;
    public Text tapToStart,currentScore,scoreText,highScore,highScore2;
    public Button pauseButton;
    public Material ground,Cylinder,Ball;
    public static GameManger instance;
    public bool gameOver,pause;
    bool gotRandom;
    Color RandomColor;
    public int score,scoreToSpeedUP;
    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
        gameOver = false;
        gotRandom = false;
        score = 0;
        scoreToSpeedUP = 10;
        highScore2.text = "HighScore :" + PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            GameOver();
        }
        PlayerPrefs.SetInt("score", score);
        currentScore.text = score.ToString();
        if (score>=scoreToSpeedUP)
        {
            GameObject.Find("Ball").GetComponent<BallController>().speed += 0.25f;
            RandomColor= new Color(Random.value, Random.value, Random.value, 1.0f);
            gotRandom = true;
            scoreToSpeedUP += 10;
        }
        if (gotRandom)
        {
            ground.color = Vector4.Lerp(ground.color, RandomColor, Time.deltaTime);
            Ball.color = Vector4.Lerp(Ball.color, RandomColor, Time.deltaTime);
	    Cylinder.color = Vector4.Lerp(Ball.color, RandomColor, Time.deltaTime);
            if (ground.color == RandomColor)
            {
                gotRandom = false;
            }
        }
    }
    public void startGame()
    {
        tapToStart.gameObject.SetActive(false);
        flappyWave.GetComponent<Animator>().Play("FlappyPanalUp");
        currentScore.GetComponent<Animator>().Play("ScoreDown");
        pauseButton.GetComponent<Animator>().Play("PauseDown");
        GameObject.Find("CylindersSpawner").GetComponent<CylindersSpawner>().startSpawn();
    }
    public void GameOver()
    {
        GameOverPanal.GetComponent<Animator>().Play("GameOver");
        currentScore.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        GameObject.Find("CylindersSpawner").GetComponent<CylindersSpawner>().stopSpawn();
        scoreText.text = score.ToString();
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score>PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
        
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void pauseContinue()
    {

        if (!pause)
        {
            pause = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            pause = false;
        }

    }
}
