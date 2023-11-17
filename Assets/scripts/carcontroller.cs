using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour
{
    public bool move = false;
    private bool isgrounded = false;
    public Rigidbody2D rb;
    public float speed = 20;
    public float rotationspeed = 7;
    public float Speed;
    public TrailRenderer trail;
    private void Update(){
    if(Input.GetButtonDown("Fire1")){
        move = true;
    }
        if (Input.GetButtonUp("Fire1")) {  move = false; }
        Speed = rb.velocity.magnitude;
   }
    private void FixedUpdate() 
    {
        if(move == true) 
        {
            if(isgrounded)
            {
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f,ForceMode2D.Force);
            }
            else
            {
                rb.AddTorque(rotationspeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            
        }
        if (Speed >= 2)
        {
            trail.emitting = true;
        }else trail.emitting=false; ;
    }
    private void OnCollisionEnter2D()
    {
        isgrounded = true;
    }
    private void OnCollisionExit2D()
    {
        isgrounded = false; ;
    }
}
