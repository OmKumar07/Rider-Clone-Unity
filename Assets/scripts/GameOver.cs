using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Transform effect;
    public SpriteRenderer player;
    public cameracontroller controller;
    public bool dead = false;
    public Transform rider;
    public AudioSource deadthSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        die();
    }
    private void die()
    {
        if (!dead)
        {
            dead = true;
            if(PlayerPrefs.GetInt("Muted") == 0)
            {
                deadthSound.Play();
            }
            Vibration.Vibrate(80);
        }
    }
    private void FixedUpdate()
    {
        if (rider.position.y <= -10)
        {
            die() ;
        }
        if (dead)
        {
            effect.gameObject.SetActive(true);
            player.enabled = false;
            if (controller.fov >= 5)
                controller.fov -= 10 * Time.fixedDeltaTime;
            controller.follow = false;
        }
    }
}
