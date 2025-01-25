using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private TMPro.TMP_Text _inputField;
    public float remainingTime; // ��ʱ��ʣ��ʱ��
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
        else if (remainingTime < 0)
        {
            // ʱ�䵽��ִ����Ϸ�����߼�
            Debug.Log("Game Over!");
            remainingTime = 0;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _inputField.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
