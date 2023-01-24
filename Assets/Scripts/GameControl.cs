using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float scrollSpeed = -1.5f;
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
     if(gameOver&&Input.GetMouseButtonDown(0))
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }   
    }


    public void BirdScored()
    {
        if(gameOver)
        {
            return;
        }
        else
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
    }


    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
