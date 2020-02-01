using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Score Elements")]
    public int score;
    public Text scoreText;

    [Header("Highscore Elements")]
    public int highScore;
    public Text highScoreText;

    [Header("Game Over Elements")]
    public GameObject gameOver;

    [Header("Audio")]
    public AudioClip[] sliceSounds;
    public AudioClip bombSound;

    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();


        gameOver.SetActive(false);
        GetHighScore();
    }

    public void IncreaseScore(int increase)
    {
        score += increase;
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "Highscore: " + score.ToString();
        }
    }

    public void GetHighScore()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void OnBombCollision()
    {
        Time.timeScale = 0;
        audioSource.PlayOneShot(bombSound);
        gameOver.SetActive(true);
        Debug.Log("Game Over");
    }

    public void Restart()
    {
        score = 0;
        scoreText.text = "0";

        GetHighScore();

        foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag("Dynamic"))
        {
            Destroy(gameObject);
        }

        gameOver.SetActive(false);

        Time.timeScale = 1;
    }

    public void PlaySliceSound()
    {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
}
