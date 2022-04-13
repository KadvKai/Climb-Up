using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] int _maxCoins = 20;
    public UnityEvent<int> NevCoins=new UnityEvent<int>();
    public int QuantityCoins { get; private set; }
    private void Awake()
    {
        QuantityCoins = 10;
        DontDestroyOnLoad(this);
    }

    public bool ChangeCoins(int coins)
    {
        var oldQuantityCoins = QuantityCoins;
        QuantityCoins += coins;
        if (QuantityCoins<0|| QuantityCoins> _maxCoins)
        {
            QuantityCoins = oldQuantityCoins;
            return false;
        }
        else
        {
            NevCoins.Invoke(QuantityCoins);
            return true;
        }
    }
}
