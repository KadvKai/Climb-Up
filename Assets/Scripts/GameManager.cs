using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Transform>  _coinsSpawnPositions;
    [SerializeField] int _coinsSpawnQuantity=25;
    [SerializeField] Ñoin _coin;
    [SerializeField] CoinsQuantity coinsQuantityIndicator;
    [SerializeField] LevelNumber _levelNumberIndicator;
    [SerializeField] Character _character;
    [SerializeField] EndCanvas _endCanvas;
    private int _levelNumber;
    void Start()
    {
        var wallet = GameObject.FindObjectOfType<Wallet>();
        coinsQuantityIndicator.SetWallet(wallet);
        SpawnCoins(wallet);
        _character.EndLevel.AddListener(EndLevel);
        _character.GameOver.AddListener(GameOver);
        _endCanvas.Continue.AddListener(NextLevel);
        _levelNumber = SceneManager.GetActiveScene().buildIndex;
        ShowLevelNumber(_levelNumber);
    }

    private void SpawnCoins(Wallet wallet) 
    {
        if (_coinsSpawnQuantity > _coinsSpawnPositions.Count) _coinsSpawnQuantity = _coinsSpawnPositions.Count;
        for (int i = 0; i < _coinsSpawnQuantity; i++)
        {
            var position = _coinsSpawnPositions[Random.Range(0, _coinsSpawnPositions.Count)];
            _coinsSpawnPositions.Remove(position);
            var coin = Instantiate(_coin, position.position,Quaternion.identity);
            coin.AddWallet(wallet);
        }
    }

    private void EndLevel()
    {
        _endCanvas.EndLevel();
    }

    private void GameOver()
    {
        _endCanvas.GameOver();
    }

    private void NextLevel()
    {
        _levelNumber++;
        ShowLevelNumber(_levelNumber);
    }

    private void ShowLevelNumber(int number)
    {
        _levelNumberIndicator.SetNumber(number);
    }
}
