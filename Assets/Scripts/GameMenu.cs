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
    [SerializeField] string gameOverMessage = "Game Over";
    [SerializeField] Canvas TooltipCanvas;
    [SerializeField] float tooltipTurnOfTime = 10;

    [SerializeField] float restartTime = 2;
    [SerializeField] float toWinTime = 1;

    private void Start()
    {
        Invoke(nameof(TurnOfToolTip), tooltipTurnOfTime);
    }

    private void TurnOfToolTip()
    {
        if (TooltipCanvas != null)
        {
            TooltipCanvas.enabled = false;
        }
    }

    public void GameOverMessage()
    {
        if (gameOverImage == null || gameOverText == null) { return; }
        gameOverImage.enabled = true;
        gameOverText.text = gameOverMessage;
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
        StartCoroutine(WinCorutine());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(restartTime);
        var currentScene = SceneManager.GetActiveScene();
        ChangeScene(currentScene.buildIndex);
    }

    IEnumerator WinCorutine()
    {
        yield return new WaitForSecondsRealtime(toWinTime);
        ChangeScene(2);
    }
}
