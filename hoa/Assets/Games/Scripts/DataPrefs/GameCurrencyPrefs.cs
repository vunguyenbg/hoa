
using Yoolax.Framework;
using System;
using System.Collections.Generic;

[Serializable]
public class GameCurrencyPrefs : BasePrefs
{
    public int money;
    public int gold;
    public int energy;
    public int keySilver;
    public int keyGold;
    public GameCurrencyPrefs(int _money, int _gold, int _energy)
    {
        money = _money;
        gold = _gold;
        energy = _energy;
    }
    public override void OnLoad()
    {

    }

    public void AddMoney(int _number)
    {
        money += _number;
        Server.Get<OnGemChanged>().Dispatch(money);
    }
    public bool SubMoney(int _number)
    {
        if (money >= _number)
        {
            money -= _number;
            Server.Get<OnGemChanged>().Dispatch(money);
            return true;
        }
        return false;
    }
    public bool EnoughMoney(int _number)
    {
        return money >= _number;
    }

    public void AddGold(int _number)
    {
        gold += _number;
        Server.Get<OnGoldChanged>().Dispatch(gold);
    }
    public bool SubGold(int _number)
    {
        if (gold >= _number)
        {
            gold -= _number;
            Server.Get<OnGoldChanged>().Dispatch(gold);
            return true;
        }
        return false;
    }
    public bool EnoughGold(int _number)
    {
        return gold >= _number;
    }

    public void AddEnergy(int _energy)
    {
        energy += _energy;
        Server.Get<OnEnergyChanged>().Dispatch(money);
    }
    public bool SubEnergy(int _energy)
    {
        if (energy >= _energy)
        {
            energy -= _energy;
            Server.Get<OnEnergyChanged>().Dispatch(money);
            return true;
        }
        return false;
    }
    public bool EnoughEnergy(int _energy)
    {
        return energy >= _energy;
    }

    public void AddSilver(int _number)
    {
        keySilver += _number;
    }
    public bool SubSilver(int _number)
    {
        if (keySilver >= _number)
        {
            keySilver -= _number;
            return true;
        }
        return false;
    }
    public bool EnoughSilver(int _number)
    {
        return keySilver >= _number;
    }

    public void AddKeyGold(int _number)
    {
        keyGold += _number;
    }
    public bool SubKeyGold(int _number)
    {
        if (keyGold >= _number)
        {
            keyGold -= _number;
            return true;
        }
        return false;
    }
    public bool EnoughKeyGold(int _number)
    {
        return keyGold >= _number;
    }

   
}
