using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

public class PlayerController : MonoBehaviour {


	public Player player;
	public float movementSpeed;
	[Range(0.01f, 0.99f), Tooltip("Deadzone for joystick movement (Left stick).")]
	public float movementDeadzone = 0.05f;
	[Range(0.01f, 0.99f), Tooltip("Deadzone for joystick rotation (Right stick).")]
	public float rotationDeadzone = 0.05f;
	public Transform cameraTrans;

	float moveAxisV;
	float moveAxisH;
	float rotAxisV;
	float rotAxisH;

	public void HandleInput(GamePadState state, GamePadState prevState)
	{
		moveAxisH = state.ThumbSticks.Left.X;
		moveAxisV = state.ThumbSticks.Left.Y;

		rotAxisH = state.ThumbSticks.Right.X;
		rotAxisV = state.ThumbSticks.Right.Y;

        if (moveAxisH > movementDeadzone || moveAxisH < -movementDeadzone)
        {
            //Movement
			float magnitude = moveAxisH<0 ? moveAxisH+movementDeadzone : moveAxisH-movementDeadzone;
			transform.position = Vector3.Lerp(transform.position, transform.position + cameraTrans.right * magnitude, Time.deltaTime * movementSpeed);
        }
        if (moveAxisV > movementDeadzone || moveAxisV < -movementDeadzone)
		{
			float magnitude = moveAxisV<0 ? moveAxisV+movementDeadzone : moveAxisV-movementDeadzone;
			var cameraforw = cameraTrans.forward;
			cameraforw.y = 0;
			cameraforw.Normalize();
			transform.position = Vector3.Lerp(transform.position, transform.position + cameraforw * magnitude, Time.deltaTime * movementSpeed);
		}
		if (rotAxisH > rotationDeadzone || rotAxisH < -rotationDeadzone || rotAxisV > rotationDeadzone || rotAxisV < -rotationDeadzone)
		{
			transform.eulerAngles = new Vector3( 0, Mathf.Atan2( rotAxisH, rotAxisV) * 180 / Mathf.PI, 0 );
			// player.Attack();
		}
	}

}
