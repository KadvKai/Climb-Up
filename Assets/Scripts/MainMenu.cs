using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text CoinsQuantity;
    private Wallet _wallet;
    private int CoinChange = 1;

    private void Awake()
    {
        _wallet = GameObject.FindObjectOfType<Wallet>();
        _wallet.NevCoins.AddListener(NevCoins);
    }
    private void Start()
    {
        CoinsQuantity.text = _wallet.QuantityCoins.ToString();
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
        if (_wallet.ChangeCoins(-CoinChange))
        {
            CoinChange++;
        }
    }

    private void NevCoins(int coins)
    {
        CoinsQuantity.text = coins.ToString();
    }
}
