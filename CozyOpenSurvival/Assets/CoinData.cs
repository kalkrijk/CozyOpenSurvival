using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Coin Data", menuName = "Game/Coin Data")]
public class CoinData : ScriptableObject
{
    public int value = 1;
    public string currencyType = "Coins";
}
