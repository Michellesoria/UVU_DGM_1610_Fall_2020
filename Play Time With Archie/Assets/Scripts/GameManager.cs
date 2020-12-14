using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> toyPrefabs;
    public GameObject Life1, Life2, Life3; 
    public GameObject food; 
    public GameObject titleScreen;
    public static int health = 3;
    private float spawnRate = 2;
    public bool isGameActive;
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        score = 0;
        StartCoroutine(SpawnToy());
        UpdateScore(0);
        


        Life1.gameObject.SetActive (true);
        Life2.gameObject.SetActive (true);
        Life3.gameObject.SetActive (true);
    }

    void Update ()
    {
        if(health > 3)
        {
            health =3;
        }

        switch(health)
        {
            case 3:
            Life1.gameObject.SetActive (true);
            Life2.gameObject.SetActive (true);
            Life3.gameObject.SetActive (true);
            break;
            case 2:
            Life1.gameObject.SetActive (true);
            Life2.gameObject.SetActive (true);
            Life3.gameObject.SetActive (false);
            break;
            case 1:
            Life1.gameObject.SetActive (true);
            Life2.gameObject.SetActive (false);
            Life3.gameObject.SetActive (false);
            break;
            case 0:
            Life1.gameObject.SetActive (false);
            Life2.gameObject.SetActive (false);
            Life3.gameObject.SetActive (false);
            GameOver();
            break;
        }
    }

    IEnumerator SpawnToy()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, toyPrefabs.Count);
            Instantiate(toyPrefabs[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void StartGame()
    {
        isGameActive = true;
        
        titleScreen.gameObject.SetActive(false);
    }
}
