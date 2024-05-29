using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_CoinsView : MonoBehaviour, ICoinsView
{
    public TextMeshProUGUI _coinsText;

    public void UpdateCoinsAmount(int amount)
    {
        if(_coinsText != null)
            _coinsText.text = "Coins: " + amount.ToString();
    }
}
