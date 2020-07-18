using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Anim
{
    IDLE,
    WALK,
    JUMP

}
public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private Anim animIndex;
    

    private void Start()
    {
        animIndex = Anim.IDLE;
    }

    public void Walk()
    {
        if (animIndex == Anim.WALK)
            return;

        _animator.Play("Player_Run");
        animIndex = Anim.WALK;
    }

    public void Jump()
    {
        if (animIndex == Anim.JUMP)
            return;

        _animator.Play("Player_Jump");
        animIndex = Anim.JUMP;
    }

    public void Idle()
    {
        if (animIndex == Anim.IDLE)
            return;

        _animator.Play("Player_Idle");
        animIndex = Anim.IDLE;
    }
}
