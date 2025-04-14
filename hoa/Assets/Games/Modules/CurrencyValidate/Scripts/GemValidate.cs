
using DG.Tweening;
using Yoolax.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemValidate : MonoBehaviour
{
    public TextMeshProUGUI txtCoin;

    private Tween tween;
    private void Start()
    {
        OnGemChanged(DataManager.Instance.GameCurrencyPrefs.gold);
    }
    private void OnEnable()
    {
        currencyValue = DataManager.Instance.GameCurrencyPrefs.gold;
        Server.Get<OnGoldChanged>().AddListener(OnGemChanged);
    }
    private void OnDisable()
    {
        Server.Get<OnGoldChanged>().RemoveListener(OnGemChanged);
    }

    void OnGemChanged(int value)
    {
        if (tween != null)
        {
            tween.Kill();
        }
        tween = txtCoin.transform.DOScale(1.3f, 0.25f).OnComplete(() =>
        {
            tween = txtCoin.transform.DOScale(1f, 0.25f);
        });
        DOTween.To(() => CurrencyValue, x => CurrencyValue = x,(int) value, 0.5f);
    }
    public void OnClick()
    {
        //PopupShopIAP.Show(ShopIAPState.gem);
    }

    int currencyValue;
    int CurrencyValue
    {
        set
        {
            currencyValue = value;
            txtCoin.text = Helper.FormatCurrency(currencyValue);
        }
        get
        {
            return currencyValue;

        }
    }

}
