using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : Singleton<MainMenu>
{
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject losePanel;

    public AudioClip winGame;
    public AudioClip loseGame;
    private GameManger gameManger;
    void Start()
    {
        gameManger = GameManger.instance;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void Win(bool state , AudioSource aud)
    {
        aud.PlayOneShot(winGame);
        gameManger.gameState = false;
        winPanel.SetActive(state);
    }
    public void Lose(bool state, AudioSource aud)
    {
        aud.PlayOneShot(loseGame);
        gameManger.gameState = false;
        losePanel.SetActive(state);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  
}
