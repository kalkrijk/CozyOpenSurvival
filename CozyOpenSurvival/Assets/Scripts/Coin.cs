using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Reference to the CoinData scriptable object
    public CoinData coinData;

    // Method to initialize the coin with the provided CoinData
    public void InitializeCoin(CoinData data)
    {
        coinData = data;
    }

    // Optional: You can add more functionality to the coin, like rotation, animation, etc.
}
