using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsModel : ICoinsModel
{
    private int _amount;
    public CoinsModel()
    {
        _amount = 0;
    }

    public int GetCoinsAmount()
    {
        return _amount;
    }
    public void AddCoin()
    {
        _amount++;
    }
}
