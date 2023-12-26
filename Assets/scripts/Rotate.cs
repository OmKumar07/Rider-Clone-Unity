using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;
    private GameOver dead;
    public bool star = true;
    public bool die = false;
    void Start()
    {
        if (star)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.AddTorque(-speed);
        }
            dead = FindObjectOfType<GameOver>();
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (!die)
            {
                die = true;
                dead.dead = true;
                if (PlayerPrefs.GetInt("Muted") == 0)
                {
                    dead.deadthSound.Play();
                }
                Vibration.Vibrate(80);
            } 
        }
        
    }
}
