using UnityEngine;
using UnityEngine.UI;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private Text CoinText; 
    // Reference to the CurrencyManager script
    public CurrencyManager currencyManager;

    private void Start()
    {
    currencyManager = CurrencyManager.instance;
    }

    private void Update()
    {
        CoinText.text = "Coins: " + currencyManager.GetCurrencyBalance("Coins");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a GameObject with CoinData script attached
        Coin coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            // Add the coin's value to the player's currency balance
            currencyManager.AddCurrency(coin.coinData.currencyType, coin.coinData.value);

            // Destroy the coin GameObject after it's picked up
            Destroy(other.gameObject);
        }
    }
}