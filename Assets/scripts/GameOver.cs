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
      Vibration.Vibrate(100);
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
            if (controller.fov >= 5)
                controller.fov -= 10 * Time.fixedDeltaTime;
            controller.follow = false;
        }
    }
}
