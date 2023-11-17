using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class cameracontroller : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool follow = true;
    public float smoothing;
    public float speed;
    public carcontroller controller;
    public float fov = 0f;
    public Camera cam;
    private void Start()
    {
        
    }
    private void Update()
    {
        offset.x = Mathf.Clamp(offset.x, 2f, 3f);
        fov = Mathf.Clamp(fov, 15f, 20f);
        
    }
    private void LateUpdate()
    {
        
    }
    private void FixedUpdate()
    {
        if (controller.move)
        {
            offset.x += Time.fixedDeltaTime*0.1f*controller.Speed; 
        }
        else if(controller.move == false)
        {
            offset.x -= Time.fixedDeltaTime * 0.1f * controller.Speed;
        }
        if (follow)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing) + offset;
        }
        if (target.position.y > 25 && controller.Speed > 5)
        {
            fov += 5 * Time.deltaTime;
            cam.orthographicSize = fov;
        }
        if (target.position.y < 25 || controller.Speed < 5)
        {
            fov -= 5 * Time.deltaTime;
            cam.orthographicSize = fov;
        }
    }


}
