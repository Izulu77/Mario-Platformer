using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_CoinsController : MonoBehaviour
{
    [SerializeField] private SC_CoinsView _sc_coinsView;
    private ICoinsModel _coins;
    private ICoinsView _coinsView;

    private void OnEnable()
    {
        SC_CoinObject.OnCoinCollision += OnCoinCollision;
    }

    private void OnDisable()
    {
        SC_CoinObject.OnCoinCollision -= OnCoinCollision;
    }

    public void Awake()
    {
        _coins = new CoinsModel();
        _coinsView = _sc_coinsView;
        UpdateView();
    }

    private void OnCoinCollision()
    {
        _coins.AddCoin();
        UpdateView();
    }

    private void UpdateView()
    {
        if (_coinsView != null && _coins != null)
            _coinsView.UpdateCoinsAmount(_coins.GetCoinsAmount());
    }
}
