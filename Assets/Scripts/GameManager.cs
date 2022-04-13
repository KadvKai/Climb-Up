using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Transform>  _coinsSpawnPositions;
    [SerializeField] int _coinsSpawnQuantity=25;
    [SerializeField] Ñoin _coin;
    [SerializeField] CoinsQuantity coinsQuantityIndicator;
    [SerializeField] PuckMover _puckL;
    [SerializeField] PuckMover _puckR;
    [SerializeField] Character _character;
    void Start()
    {
        var wallet = GameObject.FindObjectOfType<Wallet>();
        coinsQuantityIndicator.SetWallet(wallet);
        if (_coinsSpawnQuantity > _coinsSpawnPositions.Count) _coinsSpawnQuantity = _coinsSpawnPositions.Count;
        for (int i = 0; i < _coinsSpawnQuantity; i++)
        {
            var position = _coinsSpawnPositions[Random.Range(0, _coinsSpawnPositions.Count)];
            _coinsSpawnPositions.Remove(position);
            var coin = Instantiate(_coin, position.position,Quaternion.identity);
            coin.AddWallet(wallet);
        }
    }

    private void PlayLevel()
    {
    }
}
