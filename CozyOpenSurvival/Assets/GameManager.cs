using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CurrencyManager currencyManager;

    private void Start()
    {
        // List of currency types to be added to the CurrencyManager
        List<string> currencies = new List<string>() { "Coins", "Gems" };

        // Initialize the currencies in the CurrencyManager
        currencyManager.InitializeCurrencies(currencies);
    }

    private void Update()
    {
        Debug.Log(CurrencyManager.instance.GetCurrencyBalance("Coins"));
    }
}
