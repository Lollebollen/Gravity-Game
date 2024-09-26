using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] Image gameOverImage;
    [SerializeField] TMP_Text gameOverText;

    [SerializeField] float restartTime = 2;
    [SerializeField] float toWinTime = 1;
    public void GameOverMessage()
    {
        if (gameOverImage == null || gameOverText == null) { return; }
        gameOverImage.enabled = true;
        gameOverText.text = "Game Over";
        StartCoroutine(Restart());
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Debug.Log("Quit was called");
        Application.Quit();
    }

    public void Win()
    {
        //play sound or effetcs
        Invoke(nameof(ChangeScene), toWinTime);
    }

    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(restartTime);
        var currentScene = SceneManager.GetActiveScene();
        ChangeScene(currentScene.buildIndex);
    }
}
