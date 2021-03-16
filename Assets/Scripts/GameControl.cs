using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance = null;

    public GameObject gameOverText;
    public bool gameRunning = false;
    public int score = 0;
    public Text scoreText;

    public float scrollSpeed = -1.5f;

    // Als "Unity-Singleton"
    private void Awake()
    {
        // Neue Instanz speichern
        if (instance == null)
            instance = this;

        // Dieses GameObject zerstören, falls davor schon ein anderes instanziert wurde
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start() {  
        IncreaseScore();
      }

    // Update is called once per frame
    void Update()
    {
        IncreaseScore();
        // Im Pausezustand + Mausclick/Tap
        if (gameRunning == false && Input.GetMouseButtonDown(0))
        {
            // Aktuelle Scene neu laden
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////
    
    public void PlayerDied()
    {
        gameOverText.SetActive(true);
        gameRunning = false;
    }

    public void IncreaseScore()
    {
        if(Time.timeScale > 0){
            score += 1;
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
