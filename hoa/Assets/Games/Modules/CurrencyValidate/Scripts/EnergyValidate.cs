using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Yoolax.Framework;

public class EnergyValidate : MonoBehaviour
{
    public TextMeshProUGUI txtCoin;

    private void Start()
    {
        OnEnergyChanged(DataManager.Instance.GameCurrencyPrefs.energy);
    }
    private void OnEnable()
    {
        currencyValue = DataManager.Instance.GameCurrencyPrefs.energy;
        Server.Get<OnEnergyChanged>().AddListener(OnEnergyChanged);
    }
    private void OnDisable()
    {
        Server.Get<OnEnergyChanged>().RemoveListener(OnEnergyChanged);
    }

    void OnEnergyChanged(int value)
    {
        DOTween.To(() => CurrencyValue, x => CurrencyValue = x, (int)value, 0.5f);
    }
    public void OnClick()
    { 
        //PopupShopEnergy.Show();
    }

    int currencyValue;
    int CurrencyValue
    {
        set
        {
            currencyValue = value;
            //txtCoin.text = string.Format(StringKeys.splash, currencyValue, DataConnector.Instance.DB_Player.GetMaxEnergy());
        }
        get
        {
            return currencyValue;

        }
    }

}
