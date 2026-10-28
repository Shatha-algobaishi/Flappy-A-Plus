using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject winScreen;  // ÔÇÔÉ ÇáİæÒ (Win Screen)
    public int winScore = 5;      // ÚÏÏ ÇáäŞÇØ ÇáãØáæÈÉ ááİæÒ
    public BirdScript birdScript;  // ÇÌÚá åĞÇ ÇáãÊÛíÑ public áÊÚííäå İí Unity Editor
    public AudioManager audioManager;  // ãÑÌÚ Åáì AudioManager áÊÔÛíá ÕæÊ ÇáİæÒ

    void Start()
    {
        if (birdScript == null)
        {
            birdScript = FindObjectOfType<BirdScript>();
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        birdScript.OnPipePassed();

        // ÇáÊÍŞŞ ãä İæÒ ÇááÇÚÈ
        if (playerScore >= winScore)
        {
            ShowWinScreen();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    // ÏÇáÉ áÅÙåÇÑ ÔÇÔÉ ÇáİæÒ æÊÔÛíá ÕæÊ ÇáİæÒ
    public void ShowWinScreen()
    {
        winScreen.SetActive(true);  // ÅÙåÇÑ ÔÇÔÉ ÇáİæÒ
        Time.timeScale = 0;  // ÅíŞÇİ ÇááÚÈÉ

        // ÊÔÛíá ÕæÊ ÇáİæÒ
        if (audioManager != null)
        {
            audioManager.PlayWinSound();
        }
    }

    // ÏÇáÉ áÅÚÇÏÉ ÇáÊÔÛíá Ãæ ÇáÑÌæÚ ááŞÇÆãÉ ÇáÑÆíÓíÉ ÚäÏ ÇáÖÛØ Úáì ÇáÒÑ İí WinScreen
    public void PlayAgain()
    {
        winScreen.SetActive(false);  // ÅÎİÇÁ ÔÇÔÉ ÇáİæÒ
        Time.timeScale = 1;  // ÅÚÇÏÉ ÊÚííä ÇáæŞÊ Åáì ÍÇáÊå ÇáØÈíÚíÉ
        restartGame();  // ÅÚÇÏÉ ÊÔÛíá ÇááÚÈÉ
    }
        }