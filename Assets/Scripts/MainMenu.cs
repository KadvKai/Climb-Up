using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _mainMenuPanel;
    public UnityEvent PlayLevel=new UnityEvent();

    public void StartMainMenu()
    {
        _mainMenuPanel.SetActive(true);
    }
        public void PlayButton()
    {
        _mainMenuPanel.SetActive(false);
        //gameObject.SetActive(false);
        PlayLevel.Invoke();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
