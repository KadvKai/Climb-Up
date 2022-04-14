using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour
{
    [SerializeField] Text _levelNumber;

    public void SetNumber(int number)
    {
        _levelNumber.text = number.ToString();
    }
}
