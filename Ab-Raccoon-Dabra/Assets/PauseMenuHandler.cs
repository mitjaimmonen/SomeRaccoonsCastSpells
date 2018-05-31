using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
public class PauseMenuHandler : MonoBehaviour {

	public GameObject Container;
	InputManager input;
	bool isPaused;
	Player player;
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Player>();
		input = GameObject.Find("InputManager").GetComponent<InputManager>();
		input.pauseMenuHandler = this;

		Container.SetActive(false);
	}

	void Update()
	{
		if (player.CurrentHealth < 0)
		{
			Debug.Log("Dead");
			Container.SetActive(true);
			isPaused = Container.activeSelf;
		}
	}

	public void HandleInput (GamePadState state, GamePadState prevState)
	{
		if (prevState.Buttons.Start == ButtonState.Released && state.Buttons.Start == ButtonState.Pressed)
		{
			Container.SetActive(!Container.activeSelf);
			isPaused = Container.activeSelf;
		}
	}

	public void ChangeScene(string name)
	{
		SceneManager.LoadScene(name);
	}
	public void ResumeGame()
	{
		Container.SetActive(!gameObject.activeSelf);
		isPaused = Container.activeSelf;
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
