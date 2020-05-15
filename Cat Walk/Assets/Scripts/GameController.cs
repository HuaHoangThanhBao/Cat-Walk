using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore
{
    public int highScore = 0;
    public int medalScore = 0;
}

public class GameController : MonoBehaviour {

    Text scoreProcessText;

    Text medalScoreText;

    Text strawberryScoreText;

    Text highScoreText;

    Button playButton;

    PlayerScore playerScore;

    CatController player;

    int temp = 0;
    int temp1 = 0;
    int temp2 = 0;

    private void Awake()
    {
        player = FindObjectOfType<CatController>();
        scoreProcessText = GameObject.Find("Score Process").GetComponent<Text>();
        medalScoreText = GameObject.Find("Medal Score").GetComponent<Text>();
        strawberryScoreText = GameObject.Find("Strawberry Score").GetComponent<Text>();
        highScoreText = GameObject.Find("High Score").GetComponent<Text>();
        playButton = GameObject.Find("Play Button").GetComponent<Button>();
    }

    private void Start()
    {
        highScoreText.gameObject.SetActive(false);

        LoadScore();

        medalScoreText.text = getMedalScore().ToString();

    }

    private void Update()
    {
        HandleScoreWhenInGame();

        HandleScoreWhenEndGame();

        HandleMedalScore();
    }

    void HandleMedalScore()
    {
        if (!player.variables.falling_B && !player.variables.falling_T)
        {
            if (player.variables.hitStrawberry)
            {
                if (temp2 == 0)
                {
                    if (player.variables.strawberryScoreValue % 5 == 0 && player.variables.strawberryScoreValue != 0)
                    {
                        player.variables.medalScoreValue++;
                        temp2++;
                    }
                }
            }
            else temp2 = 0;
        }
    }

    float timeWait;
    int deltaTime = 0;

    void HandleScoreWhenEndGame()
    {
        if(player.variables.hitGround_B || player.variables.hitGround_T)
        {
            SubmitHighScore(player.variables.scoreValue);
            
            timeWait += Time.deltaTime;

            if(timeWait >= 0.5f)
            {
                highScoreText.gameObject.SetActive(true);
                highScoreText.text = ("Best: " + getHighScore()).ToString();

                if (deltaTime == 0)
                {
                    int finalMedalScore = player.variables.medalScoreValue + getMedalScore();

                    SubmitMedalScore(finalMedalScore);
                    medalScoreText.text = finalMedalScore.ToString();
                    deltaTime++;
                }

                playButton.gameObject.SetActive(true);
            }
        }
    }

    void HandleScoreWhenInGame()
    {
        if (!player.variables.falling_B && !player.variables.falling_T)
        {

            medalScoreText.text = (player.variables.medalScoreValue + getMedalScore()).ToString();

            if (player.variables.hitCheckPoint)
            {
                if (temp == 0)
                {
                    player.variables.scoreValue++;
                    scoreProcessText.text = player.variables.scoreValue.ToString();
                    temp++;
                }
            }
            else temp = 0;

            if(player.variables.hitStrawberry)
            {
                if (temp1 == 0)
                {
                    player.variables.strawberryScoreValue++;
                    strawberryScoreText.text = (player.variables.strawberryScoreValue + "/" + "15").ToString();
                    temp1++;
                }
            }
            else temp1 = 0;
        }
    }

    int getHighScore()
    {
        return playerScore.highScore;
    }

    int getMedalScore()
    {
        return playerScore.medalScore;
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("highScore", playerScore.highScore);
    }

    void SaveMedalScore()
    {
        PlayerPrefs.SetInt("medalScore", playerScore.medalScore);
    }

    void LoadScore()
    {
        playerScore = new PlayerScore();

        if(PlayerPrefs.HasKey("highScore"))
        {
            playerScore.highScore = PlayerPrefs.GetInt("highScore");
        }
        if (PlayerPrefs.HasKey("medalScore"))
        {
            playerScore.medalScore = PlayerPrefs.GetInt("medalScore");
        }
    }

    void SubmitHighScore(int newScore)
    {
        if(newScore > playerScore.highScore)
        {
            playerScore.highScore = newScore;
            SaveScore();
        }
    }

    void SubmitMedalScore(int newScore)
    {
        playerScore.medalScore = newScore;
        SaveMedalScore();
    }

    int stateInt = 0;

    public void GameControl()
    {
        if (stateInt == 0)
        {
            player.variables.gameBegin = true;
            playButton.gameObject.SetActive(false);
            stateInt++;
        }
        else
        {
            ReloadManager();
        }
    }

    void ReloadManager()
    {
        SceneManager.LoadScene("CatWalks");
    }
}
