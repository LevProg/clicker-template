using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InfinityParamerts : MonoBehaviour
{
    [SerializeField] private Text multyClick;
    [SerializeField] private Text multyAllIncome;
    [SerializeField] private Text multyOflain;
    [SerializeField] private Text multyPerSecond;
    private void Start()
    {
        ShopElement.updateInfinityParams += UpdateParam;
        UpdateParam();
    }
    public void UpdateParam()
    {
        multyClick.text = $"   Multiplier per click: {MainTap.CheckCoofForTapAdded()}";
        multyAllIncome.text = $"  All Income Multiplier: {MainLoop._incomeCoefficient}";
        multyOflain.text = $"  Oflain Multiplier: {MainLoop._oflainCoefficient}";
        multyPerSecond.text = $"  Per Second Multiplier: {MainLoop._perSecondsCoefficient}";
    }
}
