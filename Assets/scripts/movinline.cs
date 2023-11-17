using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movinline : MonoBehaviour
{
    private Rigidbody2D rb;
    public float gravity = 1f;
    public float waittime;
    public float rotation = 0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(waittime);
        rb.gravityScale = gravity;
        yield return new WaitForSeconds(1);
        Destroy(transform.gameObject);
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        if (transform.position.y < -10)
        {
            Destroy(transform.gameObject);
        }
    }
    private void OnCollisionEnter2D()
    {
        StartCoroutine(Move());
    }
}
