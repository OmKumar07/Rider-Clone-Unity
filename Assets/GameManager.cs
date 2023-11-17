using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public Transform player;
    private int temp = 0;
    public GameOver dead;
    private void Start()
    {
        Application.targetFrameRate = 320;
    }
    IEnumerator reload()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (player.transform.position.x < 0)
        {
            score.text = temp.ToString("0");
        }
        else
        {
            float temp2 = player.position.x;
            temp2 = temp2 / 20;
            if (temp2 < 10f)
            {
                score.text = temp2.ToString("0");
            }
            else
                score.text = temp2.ToString("00");

        }
        if(dead.dead == true)
        {
            StartCoroutine(reload());
        }
    }
}
