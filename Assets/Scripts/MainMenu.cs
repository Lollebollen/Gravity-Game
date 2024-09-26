using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Quit();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ChangeScene(1);
        }
    }

    private void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Quit()
    {
        Debug.Log("Quit was called");
        Application.Quit();
    }
}
