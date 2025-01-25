using System;
using System.Collections;
using UnityEngine;

public class SpaceCraftController : MonoBehaviour
{
    public float speed = 40.0f; // 飞船的移动速度
    public float angularSpeed = 20.0f; // 飞船的x轴旋转速度
    public float reverseSpeed = 20.0f; // 飞船的倒车速度
    public float pauseDuration = 2.0f; // 暂停时间

    private Transform trans; // 飞船的Transform组件
    private Camera mainCamera; // 主摄像头
    private Rigidbody rb; // 飞船的Rigidbody组件
    private Vector3 lastPosition;
    private void Awake()
    {
        trans = GetComponent<Transform>();
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.freezeRotation = true;
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the speed (distance per second)
        // Update the last position
        lastPosition = transform.position; 
        Vector3 targetDirection = mainCamera.transform.forward;
        Quaternion targetRotationXY = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion zRotation = Quaternion.Euler(0, -90, 0);
        Quaternion finalRotation = targetRotationXY * zRotation;
        if (Math.Abs(targetDirection.x) >= 0.08 || Math.Abs(targetDirection.y) >= 0.08)
        {
            trans.rotation = Quaternion.RotateTowards(trans.rotation, finalRotation, angularSpeed * Time.deltaTime);
        }
        else
        {
            trans.rotation = trans.rotation;
        }
        
        rb.velocity = trans.right * speed;
    }

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
