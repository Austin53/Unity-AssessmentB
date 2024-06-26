using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame() => SceneManager.LoadScene(0);
    public void PlayGame() => panel.SetActive(false);
}
