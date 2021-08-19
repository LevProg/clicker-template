using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutWidthAspect : MonoBehaviour
{
    [SerializeField] private bool isTextContainer;
    private RectTransform rectTransfrom;
    void Start()
    {
        rectTransfrom = gameObject.GetComponent<RectTransform>();
        if (isTextContainer)
        {
            rectTransfrom.sizeDelta = new Vector2(0, Screen.height / 6.5f);
        }
        else
        {
            rectTransfrom.sizeDelta = new Vector2(0, Screen.height / 5.5f);
        }
    }
}
