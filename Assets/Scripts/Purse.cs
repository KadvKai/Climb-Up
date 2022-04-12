using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Purse : MonoBehaviour
{
    [SerializeField] int _maxCoins = 20;
    public UnityEvent<int> NevCoins=new UnityEvent<int>();
    public int AmountCoins { get; private set; }
    private void Awake()
    {
        AmountCoins = 10;
        DontDestroyOnLoad(this);
    }

    public bool ChangeCoins(int coins)
    {
        var oldAmountCoins = AmountCoins;
        AmountCoins += coins;
        if (AmountCoins<0|| AmountCoins> _maxCoins)
        {
            AmountCoins = oldAmountCoins;
            return false;
        }
        else
        {
            NevCoins.Invoke(AmountCoins);
            return true;
        }
    }
}
