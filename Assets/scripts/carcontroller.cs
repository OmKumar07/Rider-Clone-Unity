using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GridBrushBase;

public class carcontroller : MonoBehaviour
{
    public bool move = false;
    public bool isgrounded = false;
    public Rigidbody2D rb;
    public float Accelaration = 20;
    public float rotationspeed = 7;
    public float Speed;
    public TrailRenderer trail;
    public float Spin = 0;
    public Slider slider;
    public TextMeshProUGUI multiplyertext;
    public int scoremultiplyer;
    private float maxslidervalue = 100;
    public GameManager gameManager;
    public AudioSource audioSource;

    private void Start()
    {
        scoremultiplyer = 1;
    }
    private void OnCollisionEnter2D()
    {
        isgrounded = true;
    }
    private void OnCollisionExit2D()
    {
        isgrounded = false; ;
    }
    private void Update(){
    if(Input.GetButtonDown("Fire1")){
        move = true;
    }
        if (Input.GetButtonUp("Fire1")) 
        {  
            move = false; 
        }
        Speed = rb.velocity.magnitude;
        if (transform.position.y <= 1 && transform.rotation.z<20) { isgrounded = true; }
        if (transform.position.y >= 30) { isgrounded = false; }        
    }
    private void FixedUpdate()
    {
        if (move == true)
        {
            if (isgrounded)
            {
                rb.AddForce(transform.right * Accelaration * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            else
            {
                rb.AddTorque(rotationspeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }

        }
    }
    private void LateUpdate()
    {
       
        if (Speed >= 2)
        {
            trail.emitting = true;
        }
        else trail.emitting = false;

        //Debug.Log(this.transform.rotation.z);
        if(this.transform.rotation.z >= 0.9f && !isgrounded)
        {
            Spin++;
        }
        if(this.transform.rotation.z <= -0.9f && !isgrounded)
        {
            if (!gameManager.ispaused)
            {
                Spin++;
            }
        }
        if (Spin > 0)
        {
            if (!gameManager.ispaused)
                Spin = Spin - 1.5f * Time.fixedDeltaTime;
        }
        if (Spin >= maxslidervalue)
        {
            maxslidervalue = Spin * 1.5f;
            Spin = 0;
            scoremultiplyer += 1;
            slider.value = 0;
            slider.maxValue = maxslidervalue;
            audioSource.Play();
        }
        slider.value = Spin;
        multiplyertext.text = scoremultiplyer.ToString("0");
    }
    private IEnumerator ground()
    {
        yield return new WaitForSeconds(1);
        isgrounded=true;
        yield return new WaitForSeconds(0.2f);
        isgrounded = false;
    }
}
