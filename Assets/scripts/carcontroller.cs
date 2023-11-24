using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour
{
    public bool move = false;
    public bool isgrounded = false;
    public Rigidbody2D rb;
    public float Accelaration = 20;
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
                rb.AddForce(transform.right * Accelaration * Time.fixedDeltaTime * 100f,ForceMode2D.Force);
            }
            else
            {
                rb.AddTorque(rotationspeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            
        }
        if (Speed >= 2)
        {
            trail.emitting = true;
        }else trail.emitting=false;
        if(transform.position.y<=1) { isgrounded = true; }
        if(transform.position.y>=30) { isgrounded = false; }

    }
    private void OnCollisionEnter2D()
    {
        isgrounded = true;
    }
    private void OnCollisionExit2D()
    {
        isgrounded = false; ;
    }
    private IEnumerator ground()
    {
        yield return new WaitForSeconds(1);
        isgrounded=true;
        yield return new WaitForSeconds(0.2f);
        isgrounded = false;
    }
}
