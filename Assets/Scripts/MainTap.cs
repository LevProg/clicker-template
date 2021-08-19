using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTap : MonoBehaviour
{
    private static float _coofForTapAdded;
    [SerializeField] private bool isHasParticles;
    [SerializeField] private GameObject Tap_Partical_Parent, tap_effect;
    [SerializeField] private GameObject Click_Parent, Click_Parent_Prefab;
    [SerializeField] private Image bigTapIcon;
    [SerializeField] private Image smallTapIcon;
    [SerializeField] private Sprite[] tapIconImages;

    private ClickObj[] clickTextPool = new ClickObj[15];

    private int clickNum;
    private void Awake()
    {
        _coofForTapAdded = PlayerPrefs.GetFloat("_coofForTapAdded", .5f);
    }
    private void Start()
    {
        ShopElement.updateInfinityParams += CheckTapSprite;
        ShopElement.updateElementPanel += CheckTapSprite; ;
        _coofForTapAdded = PlayerPrefs.GetFloat("_coofForTapAdded", .5f);
        for (int i = 0; i < clickTextPool.Length; i++)
        {
            clickTextPool[i] = Instantiate(Click_Parent_Prefab, Click_Parent.transform).GetComponent<ClickObj>();
        }
        CheckTapSprite();
    }
    private void CheckTapSprite()//This function changes the image on the tap button, depending on the maximum purchased upgrade
    {
        bigTapIcon.sprite = tapIconImages[0];
        smallTapIcon.sprite = tapIconImages[1];

        if (PlayerPrefs.GetInt($"UP-{3}", 0) > 0)
        {
            bigTapIcon.sprite = tapIconImages[2];
            smallTapIcon.sprite = tapIconImages[3];
        }
        if(PlayerPrefs.GetInt($"UP-{5}", 0) > 0)
        {
            bigTapIcon.sprite = tapIconImages[4];
            smallTapIcon.sprite = tapIconImages[5];
        }
    }
    public static void UpdateCoofForTapAdded(float coof)
    {
        _coofForTapAdded = coof;
        PlayerPrefs.SetFloat("_coofForTapAdded", _coofForTapAdded);
    }
    public static float CheckCoofForTapAdded()
    {
        return _coofForTapAdded;
    }
    public void Tap()
    {
        MainLoop.AddMicrochips(MainLoop.CheckMicrochipsPerSecond()*_coofForTapAdded);
        if (isHasParticles)
        {
            Instantiate(tap_effect, Tap_Partical_Parent.transform.position, Quaternion.identity);
        }
        clickTextPool[clickNum].StartMotion(CountsUIView.TransforCount(MainLoop.CheckMicrochipsPerSecond() * _coofForTapAdded*MainLoop._incomeCoefficient));
        clickNum = clickNum == clickTextPool.Length - 1 ? 0 : clickNum + 1;
    }
}
