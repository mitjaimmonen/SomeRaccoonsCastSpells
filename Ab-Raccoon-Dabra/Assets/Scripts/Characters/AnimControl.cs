using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl {

    public Animator animator;    

    public AnimControl()
    {

    }

    public AnimControl(Animator anim)
    {
        animator = anim;
    } 

    public void PlayHurtAnimation()
    {
        animator.SetTrigger("GotHurt");
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void PlayDeathAnimation()
    {
        animator.SetBool("Dead", true);
        animator.SetTrigger("Die");
        Debug.Log("Play dead!");
    }

    public void Freeze()
    {
        animator.speed = 0;
    }

    public void Unfreeze()
    {
        animator.speed = 1;
    }

    public virtual void PlaySpellAnimation()
    {
        //nothing
    }

    public virtual void SetVerticalMagnitude(float mag)
    {
        //nothing
    }

    public virtual void SetHorizontalMagnitude(float mag)
    {
        //nothing
    }

}
