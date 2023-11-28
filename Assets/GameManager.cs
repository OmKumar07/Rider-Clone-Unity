using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public Transform player;
    private int temp = 0;
    public GameOver dead;
    public GameObject Mainmenu;
    public GameObject InGameCanvas;
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI BestScore;
    public GameObject Tutorial;
    public GameObject TutorialForward;
    public GameObject TutorialRotate;
    public GameObject TutorialBAckground;
    public AudioSource MainMenuAudio;
    public AudioClip[] clips;
    public int randint;
    public int randint2;
    public carcontroller controller;
    public GameObject MusicButton;
    public GameObject MusicButton2;
    public GameObject PauseMenu;
    public bool ispaused;
    private void Start()
    {
        randint = Random.Range(0,clips.Length);
        randint2 = Random.Range(0,clips.Length);
        Application.targetFrameRate = 320;
        MainMenuAudio.clip = clips[randint];
        if (PlayerPrefs.GetInt("Muted") == 0)
        {
            MainMenuAudio.Play();
            MusicButton.SetActive(true);
            MusicButton2.SetActive(false);
        }
        else
        {
            MainMenuAudio.Pause();
            MusicButton.SetActive(false);
            MusicButton2.SetActive(true);
        }
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            Tutorial.SetActive(true);
            PlayerPrefs.SetFloat("HighScore", 0);
            Time.timeScale = 0.3f;
        }
        Application.targetFrameRate = 320;
        MainMenuAudio.clip = clips[randint];
    }
    IEnumerator reload()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        
        float finalscore = player.position.x;

        if (player.transform.position.x < 0)
        {
            score.text = temp.ToString("0");
        }
        else
        {
            finalscore = (finalscore / 20) * controller.scoremultiplyer;
            if (finalscore < 10f)
            {
                score.text = finalscore.ToString("0");
            }
            else
                score.text = finalscore.ToString("00");

        }
        if(dead.dead == true)
        {
            PlayerPrefs.SetFloat("CurrentScore", finalscore);
            StartCoroutine(reload());
        }
        
        if (finalscore < 10f)
        {
            CurrentScore.text = PlayerPrefs.GetFloat("CurrentScore").ToString("0");
        }
        else
            CurrentScore.text = PlayerPrefs.GetFloat("CurrentScore").ToString("00");
        if (PlayerPrefs.GetFloat("HighScore") < PlayerPrefs.GetFloat("CurrentScore"))
        {
            PlayerPrefs.SetFloat("HighScore", PlayerPrefs.GetFloat("CurrentScore"));
        }
        if (PlayerPrefs.GetFloat("HighScore") < 10f)
        {
            BestScore.text = PlayerPrefs.GetFloat("HighScore").ToString("0");
        }
        else
            BestScore.text = PlayerPrefs.GetFloat("HighScore").ToString("00");

    }
    public void Disable()
    {
        TutorialForward.SetActive(false);
        TutorialBAckground.SetActive(false);
        StartCoroutine(EnableTutRotate());
        Time.timeScale = 1;
    }
    public void Disable2()
    {
        TutorialRotate.SetActive(false);
        TutorialBAckground.SetActive(false);
        PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
        Time.timeScale = 1;
    }
    public IEnumerator EnableTutRotate()
    {
        yield return new WaitForSeconds (3);
        TutorialRotate.SetActive(true);
        TutorialBAckground.SetActive (true);
        Time.timeScale = 0.3f;
    }
    public void startGAme()
    {
        Time.timeScale = 1;
        MainMenuAudio.clip = clips[randint2];
        if (PlayerPrefs.GetInt("Muted") == 0)
            MainMenuAudio.Play();
        Mainmenu.SetActive(false);
        InGameCanvas.SetActive(true);
    }
    public void mute()
    {
            PlayerPrefs.SetInt("Muted", 1);
            MainMenuAudio.Pause();
            MusicButton2.SetActive(true);
            MusicButton.SetActive(false );
    }
    public void unmute()
    {
        PlayerPrefs.SetInt("Muted", 0);
        MainMenuAudio.Play();
        MusicButton.SetActive(true);
        MusicButton2.SetActive(false);
    }
    public void pause()
    {
        PauseMenu.SetActive(true);
        MainMenuAudio.Pause();
        Time.timeScale = 0;
        ispaused = true;
    }
    public void Continue() 
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        ispaused = false;
        if(PlayerPrefs.GetInt("Muted") == 0) 
        {
            MainMenuAudio.Play();
        }
    }
    public void mainmenu()
    {
        Continue();
        dead.dead = true;
    }
}
