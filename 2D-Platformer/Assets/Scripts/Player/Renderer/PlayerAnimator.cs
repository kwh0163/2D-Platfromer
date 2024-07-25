using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerJump()
    {
        animator.ResetTrigger("Landed");
        animator.SetTrigger("Jump");
    }
    public void JumpToFall()
    {
        animator.SetTrigger("JumpToFall");
    }
    public void TriggerFall()
    {
        animator.SetTrigger("Fall");
    }
    public void TriggerLanded()
    {
        animator.SetTrigger("Landed");
    }
    public void SetIsRunning(bool _isRunning)
    {
        animator.SetBool("IsRunning", _isRunning);
    }
}
