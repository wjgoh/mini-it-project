using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    public int currency; // The current amount of currency
    public TextMeshProUGUI currencyText; // The TextMeshProUGUI element that displays the currency

    // Start is called before the first frame update
    void Start()
    {
        // Initialize currency to a value, for example 0
        currency = 0;

        // Update the currency text
        UpdateCurrencyText();
    }

    // Method to add currency
    public void AddCurrency(int amount)
    {
        currency += amount;
        UpdateCurrencyText();
    }

    // Method to subtract currency
    public void SubtractCurrency(int amount)
    {
        currency -= amount;
        UpdateCurrencyText();
    }

    // Method to update the currency text
    private void UpdateCurrencyText()
    {
        currencyText.text = currency.ToString();
    }
}