using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private TMPro.TMP_Text _inputField;
    public float remainingTime; // 计时器剩余时间
    void Awake()
    {
        _inputField = GetComponentInChildren<TMPro.TMP_Text>();
    }

    void Start()
    {
        remainingTime = 60;
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            DisplayTime(remainingTime);
        }
        else
        {
            // 时间到，执行游戏结束逻辑
            Debug.Log("Game Over!");
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _inputField.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
