using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

public class Player : Character
{

    public float movementSpeed;
    [Range(0.01f, 0.99f), Tooltip("Deadzone for joystick movement (Left stick).")]
    public float movementDeadzone = 0.05f;
    [Range(0.01f, 0.99f), Tooltip("Deadzone for joystick rotation (Right stick).")]
    public float rotationDeadzone = 0.05f;
    public CapsuleCollider playerCollider;

    float moveAxisV;
    float moveAxisH;
    float rotAxisV;
    float rotAxisH;


    private void Awake()
    {
        health = new Health(maxHealth);

        animControl = new PlayerAnimControl(GetComponentInChildren<Animator>());
    }


    public void HandleInput(GamePadState state, GamePadState prevState)
    {
        if (health.isAlive())
        {
            HandleMove(state);
            HandleRotating(state); //Also basic attack

            HandleSpells(state, prevState);
        }
    }

    void HandleMove(GamePadState state)
    {
        moveAxisH = state.ThumbSticks.Left.X;
        moveAxisV = state.ThumbSticks.Left.Y;

        animControl.SetVerticalMagnitude(moveAxisH);


        if (moveAxisH > movementDeadzone || moveAxisH < -movementDeadzone)
        {
            //Movement
            float magnitude = moveAxisH < 0 ? moveAxisH + movementDeadzone : moveAxisH - movementDeadzone;
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right * magnitude, Time.deltaTime * movementSpeed);
            animControl.SetVerticalMagnitude(moveAxisH);

        }
        if (moveAxisV > movementDeadzone || moveAxisV < -movementDeadzone)
        {
            float magnitude = moveAxisV < 0 ? moveAxisV + movementDeadzone : moveAxisV - movementDeadzone;
            var cameraforw = Vector3.forward;

            cameraforw.y = 0;
            cameraforw.Normalize();
            transform.position = Vector3.Lerp(transform.position, transform.position + cameraforw * magnitude, Time.deltaTime * movementSpeed);
            animControl.SetVerticalMagnitude(moveAxisV);
        }
    }
    void HandleRotating(GamePadState state)
    {
        rotAxisH = state.ThumbSticks.Right.X;
        rotAxisV = state.ThumbSticks.Right.Y;

        if (rotAxisH > rotationDeadzone || rotAxisH < -rotationDeadzone || rotAxisV > rotationDeadzone || rotAxisV < -rotationDeadzone)
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(rotAxisH, rotAxisV) * 180 / Mathf.PI, 0);
            //animControl.SetHorizontalMagnitude(????);
            Attack();
        }
    }

    void HandleSpells(GamePadState state, GamePadState prevState)
    {
        // Detect if a button was pressed this frame
        if (prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed)
        {
            Attack(equippedSpell);
        }

        if (prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            ++EquippedSpell;
        }
    }


	protected override void DIE()
	{
		//Play dead animation
		if (!destroying)
		{
            animControl.PlayDeathAnimation();
			if (deathSound != "")
				FMODUnity.RuntimeManager.PlayOneShot(deathSound, transform.position);
			destroying = true;
		}

	}


}
