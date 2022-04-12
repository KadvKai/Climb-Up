using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text CoinsQuantity;
    private Purse _purse;
    private int CoinChange = 1;

    private void Awake()
    {
        _purse = GameObject.Find("Purse").GetComponent<Purse>();
        _purse.NevCoins.AddListener(NevCoins);
    }
    private void Start()
    {
        CoinsQuantity.text = _purse.AmountCoins.ToString();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void CoinsButton()
    {
        if (_purse.ChangeCoins(-CoinChange))
        {
            CoinChange++;
        }
    }

    private void NevCoins(int coins)
    {
        CoinsQuantity.text = coins.ToString();
    }
}
