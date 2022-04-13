using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Сoin : MonoBehaviour
{
    private Wallet _wallet;
    public void AddWallet(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_wallet != null) _wallet.ChangeCoins(1);
        Destroy(gameObject);
    }
}
