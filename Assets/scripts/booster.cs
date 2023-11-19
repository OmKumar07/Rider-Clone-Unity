using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    public int boost;
    public bool reverse = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = Player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            rb.AddForce(transform.right*boost , ForceMode2D.Impulse);
        }
        if(reverse)
        {
            if (collision.transform.tag == "Player")
            {
                rb.AddForce(-transform.right , ForceMode2D.Impulse);
            }
        }
        
    }
}
