using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsQuantity : MonoBehaviour
{
    [SerializeField] Text _coinsQuantityText;

    public void SetWallet(Wallet wallet)
    {
        if (wallet!=null)
        {
        wallet.NevCoins.AddListener(NevCoins);
        _coinsQuantityText.text = wallet.QuantityCoins.ToString();
        }
    }

    private void NevCoins(int quantityCoins)
    {
        _coinsQuantityText.text = quantityCoins.ToString();
    }
}
