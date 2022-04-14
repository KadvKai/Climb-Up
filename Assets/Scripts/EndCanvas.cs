using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EndCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _endLevelScreen;
    public UnityEvent Continue = new UnityEvent();

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
        _endLevelScreen.SetActive(false);
    }
    public void EndLevel()
    {
        _endLevelScreen.SetActive(true);
        _gameOverScreen.SetActive(false);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ContinueButton()
    {
        Continue.Invoke();
    }
}
