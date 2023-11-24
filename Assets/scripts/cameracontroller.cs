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

    private void FixedUpdate()
    {
        if (follow)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing) + offset;
            if (target.position.y > 15 && controller.Speed > 5 && fov <= 20f)
            {
                fov += 5 * Time.deltaTime;
                cam.orthographicSize = fov;
            }
            if (target.position.y < 15 || controller.Speed < 5)
            {
                if (fov > 15f)
                {
                    fov -= 5 * Time.deltaTime;
                    cam.orthographicSize = fov;
                }
            }
        }
        cam.orthographicSize = fov;
    }


}
