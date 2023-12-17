using System;
using TMPro;
using UnityEngine;
using Utility;

public class Money : MonoBehaviour
{
    private int money = 400;
    private TextMeshProUGUI moneyField;
    private void Awake()
    {
        moneyField = GameObjectUtility.findChild(GameObjectUtility.findChild(gameObject, "Canvas"),"Score").GetComponent<TextMeshProUGUI>();
        updateField();
    }

    public bool canIncrease(int amount)
    {
        return money + amount >= 0;
    }
    
    public void increase(int amount) 
    {
        if (canIncrease(amount))
        {
            money += amount;
            updateField();
            Debug.Log(money);
        }
        else
        {
            throw new MoneyException();
        }
    }

    public bool canDecrease(int amount)
    {
        return canIncrease(-amount);
    }
    
    public void decrease(int amount)
    {
        increase(-amount);
    }

    private void updateField()
    {
        moneyField.text = money.ToString();
    }
}

public class MoneyException : Exception
{
    
}
