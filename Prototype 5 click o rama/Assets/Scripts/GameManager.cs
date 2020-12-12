using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titileScreen; 
    public bool isGameActive; 
    private int score;
    private float spawnRate = 2; 

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            //spawns objects every spawn rate depending on difficulty 
            yield return new WaitForSeconds(spawnRate);
            //selects random object in the list
            int index = Random.Range(0, targets.Count);
            //spawns object
            Instantiate(targets[index]);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE: " + score; 
    }

    public void GameOver()
    {
        //game over text and button appear when game is over
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        //resart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());   
        UpdateScore(0);
        titileScreen.gameObject.SetActive(false);
    }
}
