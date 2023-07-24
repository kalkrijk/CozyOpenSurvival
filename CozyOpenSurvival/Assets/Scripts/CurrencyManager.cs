using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    public Dictionary<string, int> currencyBalances = new Dictionary<string, int>();

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Method to initialize currency balances
    public void InitializeCurrencies(List<string> currencyTypes)
    {
        foreach (string currencyType in currencyTypes)
        {
            currencyBalances[currencyType] = 0;
        }
    }

    // Method to add currency to the player's balance
    public void AddCurrency(string currencyType, int amount)
    {
        if (currencyBalances.ContainsKey(currencyType))
        {
            currencyBalances[currencyType] += amount;
        }
        else
        {
            Debug.LogWarning("Currency type not found:" + currencyType);
        }
    }

    // Method to subtract currency from the player's balance
    public bool SubtractCurrency(string currencyType, int amount)
    {
        if (currencyBalances.ContainsKey(currencyType) && currencyBalances[currencyType] > amount)
        {
            currencyBalances[currencyType] -= amount;
            return true;
        }
        else
        {
            Debug.LogWarning("Not enough currency: " + currencyType);
            return false;
        }
    }

    public bool ConvertCurrency(string fromCurrency,  string toCurrency, int amount)
    {
        if (currencyBalances.ContainsKey(fromCurrency) && currencyBalances[fromCurrency] > amount)
        {
            currencyBalances[fromCurrency] -= amount;
            AddCurrency(toCurrency, amount);
            return true;
        }
        else
        {
            Debug.LogWarning("Not enough currency:" + fromCurrency);
            return false;
        }
    }

    public int GetCurrencyBalance(string currencyType)
    {
        if (currencyBalances.ContainsKey(currencyType))
        {
            return currencyBalances[currencyType];
        }
        else
        {
            Debug.LogWarning("Currency type not found: " + currencyType);
            return 0;
        }
    }
}
