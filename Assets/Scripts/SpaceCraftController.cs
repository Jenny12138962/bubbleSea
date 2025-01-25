using System;
using System.Collections;
using UnityEngine;

public class SpaceCraftController : MonoBehaviour
{
    public float speed = 40.0f; // 飞船的移动速度
    public float angularSpeed = 20.0f; // 飞船的x轴旋转速度
    public float reverseSpeed = 20.0f; // 飞船的倒车速度
    public float pauseDuration = 2.0f; // 暂停时间


    public IEnumerator PauseMovement()
    {
        float originalSpeed = speed;
        speed = 0; // 暂停移动
        Debug.Log("PauseMovement");
        yield return new WaitForSeconds(pauseDuration); // 暂停两秒
        speed = originalSpeed; // 恢复移动
        Debug.Log("ResumeMovement");
    }
}
