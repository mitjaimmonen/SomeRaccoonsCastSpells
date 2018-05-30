using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public Animator transitionAnim;
    public int gameScene;
  

   public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("fade");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(gameScene);
    }
}
