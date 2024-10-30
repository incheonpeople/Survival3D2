using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue; // (41) ������� ���簪
    public float startValue; // (42)
    public float maxValue; // (43)
    public float passiveValue; // (44)
    public Image uiBar; // (45)

    private void Start()
    {
        curValue = startValue; // (46)
    }

    void Update()
    {
        uiBar.fillAmount = GetPercentage(); // (48) // fillAmount ���� ���ο� ���� �� curValue�� ����
    }

    float GetPercentage()
    {
        return curValue / maxValue; // (47)
    }

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue); // (49) 
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0); // (50)
    }
}
