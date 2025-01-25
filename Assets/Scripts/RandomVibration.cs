using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVibration : MonoBehaviour
{
    public float amplitude = 1.0f; // 振幅
    public float frequency = 1.0f; // 频率
    private float randomOffset; // 随机偏移量
    private float origin_y;

    // Start is called before the first frame update
    void Start()
    {
        randomOffset = Random.Range(0f, 2f * Mathf.PI); // 随机偏移量
        origin_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float y = amplitude * Mathf.Sin(Time.time * frequency + randomOffset) + origin_y;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}