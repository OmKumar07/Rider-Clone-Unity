using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMove : MonoBehaviour
{
    private Animator mAnimator;
    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        mAnimator.SetTrigger("New Trigger");
    }
}
