using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopElement : MonoBehaviour
{
    #region private fields
    [SerializeField] private bool isInfinityUpgrates;
    [SerializeField] private int index;
    [SerializeField] private int _startCost;
    [SerializeField] private int _incomePerSecond;
    [SerializeField] private Text _costText;
    [SerializeField] private Text _numberPurchasesText;
    [SerializeField] private GameObject _panel;

    private const float coofForNextPurchase=1.5f;
    private const float coofForNextInfinityPurchase = 5f;
    private int _numberPurchases;
    private float _cost;
    # endregion private fields

    public delegate void UpdateParamerts();
    public static event UpdateParamerts updateInfinityParams;
    public static event UpdateParamerts updateElementPanel;


    void Start()
    {
        _numberPurchases = PlayerPrefs.GetInt($"UP-{index}", 0);
        updateInfinityParams += UpdateCost;
        updateInfinityParams += CheckPanel;
        updateElementPanel += CheckPanel;
        CheckPanel();
        UpdateCost();
    }

    private void CheckPanel()
    {
        if (isInfinityUpgrates) 
            return;

        if (PlayerPrefs.GetInt($"UP-{index - 1}", 0) > 0)
        {
            _panel.SetActive(false);
        }
        else
        {
            _panel.SetActive(true);
        }
    }
    public void UpdateCost()
    {
        _numberPurchases = PlayerPrefs.GetInt($"UP-{index}", 0);
        if (isInfinityUpgrates)
        {
            _cost = _startCost * Mathf.Pow(coofForNextInfinityPurchase, _numberPurchases);//Formula of geometric progression
        }
        else
        {
            _cost = _startCost * Mathf.Pow(coofForNextPurchase, _numberPurchases);//Formula of geometric progression
        }
        _costText.text = $"Cost: {CountsUIView.TransforCount(_cost)}";
        _numberPurchasesText.text = $"You have: {CountsUIView.TransforCount(_numberPurchases)}";
    }
    public void Buy()
    {
        UpdateCost();
        if (MainLoop.CheckMicrochips()>=_cost)
        {
            _numberPurchases += 1;
            PlayerPrefs.SetInt($"UP-{index}", _numberPurchases);
            if (isInfinityUpgrates)
            {
                switch (index)
                {
                    case 50:
                        MainTap.UpdateCoofForTapAdded(.5f + 0.1f * _numberPurchases);//click Coefficient
                        break;

                    case 51:
                        MainLoop._oflainCoefficient = 1 + 0.1f * _numberPurchases;//oflain Coefficient
                        break;

                    case 52:
                        MainLoop._perSecondsCoefficient = 1 + 0.1f * _numberPurchases;//incom per second Coefficient
                        break;

                    case 53:
                        MainLoop._incomeCoefficient = 1 + 0.1f * _numberPurchases;//all incom Coefficient
                        break;
                }
                MainLoop.ResetProgress();
                updateInfinityParams?.Invoke();
            }
            else
            {
                updateElementPanel?.Invoke();
                MainLoop.ReduceMicrochips(_cost);
                MainLoop.AddMicrochipsPerSecond(_incomePerSecond);
            }
            UpdateCost();
        }

    }
}
