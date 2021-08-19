using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickObj : MonoBehaviour
{
    private bool isMove;
    private Vector2 randomVector;

    private void Update()
    {
        if (!isMove) return;

        transform.Translate(randomVector * Time.deltaTime);
    }

    public void StartMotion(string incrMoney)
    {
        transform.localPosition = Vector2.zero;
        GetComponent<Text>().text = "+" + incrMoney;
        randomVector = new Vector2(Random.Range(-2,2), Random.Range(-2, 2));
        isMove = true;
        GetComponent<Animation>().Play();
    }

    public void StopMotion()
    {
        isMove = false;
    }
}
