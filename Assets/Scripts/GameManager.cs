using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] MainMenu _mainMenu;
    void Start()
    {
        _mainMenu.PlayLevel.AddListener(PlayLevel);
        _mainMenu.StartMainMenu();
    }

    private void PlayLevel()
    {
        _mainMenu.PlayLevel.RemoveListener(PlayLevel);
    }
}
