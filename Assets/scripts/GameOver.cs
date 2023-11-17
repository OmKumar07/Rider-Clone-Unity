using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Transform effect;
    public SpriteRenderer player;
    public cameracontroller controller;
    [HideInInspector]
    public bool dead = false;
    public Transform rider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
      dead = true;
    }
    private void FixedUpdate()
    {
        if(rider.position.y <= -10)
        {
          dead = true;
        }
        if (dead)
        {
            effect.gameObject.SetActive(true);
            player.enabled = false;
            controller.follow = false;
        }
    }
}
