using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Text playerHealth,wave,highscore;

    Button pauseButton;
    public Button resumeButton;

    public GameObject youDiedMenu,pauseMenu;
    void Start()
    {
        playerHealth=GameObject.Find("Health").GetComponent<Text>();
        wave= GameObject.Find("Wave").GetComponent<Text>();
        highscore=GameObject.Find("Score").GetComponent<Text>();
        pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        
    }


    void Update()
    {
        playerHealth.text = "Health: " + GameManager.Instance.CharacterManager.health;
        wave.text = "Wave " + GameManager.Instance.LevelManager.wavecount;
        highscore.text = "Score: " + GameManager.Instance.highscore;
        pauseButton.onClick.AddListener(() => { PauseGame(); });
        resumeButton.onClick.AddListener(() => { ResumeGame(); });
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void YouDied()
    {
        Time.timeScale = 0;
        youDiedMenu.SetActive(true);
    }

    
}
