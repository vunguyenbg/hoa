using DG.Tweening;
using Yoolax.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldValidate : MonoBehaviour
{
    public TextMeshProUGUI txtCoin;

    private Tween tween;

    private void Start()
    {
        OnValueChanged(DataManager.Instance.GameCurrencyPrefs.money);
    }
    private void OnEnable()
    {
        currencyValue = DataManager.Instance.GameCurrencyPrefs.money;
        Server.Get<OnGemChanged>().AddListener(OnValueChanged);
    }
    private void OnDisable()
    {
        Server.Get<OnGemChanged>().RemoveListener(OnValueChanged);
    }

    void OnValueChanged(int value)
    {
        if (tween != null)
        {
            tween.Kill();
        }
        tween = txtCoin.transform.DOScale(1.3f, 0.25f).OnComplete(() =>
        {
            tween = txtCoin.transform.DOScale(1f, 0.25f);
        });
        DOTween.To(() => CurrencyValue, x => CurrencyValue = x, value, 0.5f);

    }

    int currencyValue;
    int CurrencyValue
    {
        set
        {
            currencyValue = value;
            txtCoin.text = Helper.FormatCurrency(currencyValue);//currencyValue.ToString();

        }
        get
        {
            return currencyValue;

        }
    }

}
