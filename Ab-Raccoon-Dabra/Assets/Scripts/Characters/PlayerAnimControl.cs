using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : AnimControl
{

    public PlayerAnimControl(Animator anim)
    {
        animator = anim;
    }

    public override void SetVerticalMagnitude(float mag)
    {
        animator.SetFloat("MagnitudeY", mag);
    }

    public override void PlaySpellAnimation()
    {
        animator.SetTrigger("Spell");
    }

    public override void SetHorizontalMagnitude(float mag)
    {
        animator.SetFloat("MagnitudeX", mag);
    }

}
