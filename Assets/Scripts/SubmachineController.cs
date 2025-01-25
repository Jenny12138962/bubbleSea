using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SubmachineController : MonoBehaviour
{
    public float speed = 5.0f;
    public float angularSpeed = 20.0f;
    public float pauseDuration;
    private Transform trans;
    private Camera mainCamera;
    private Rigidbody rb;
    private TeleportController teleportController;
    private Vector3 lastPosition;
    private XRJoystick joystick;
    private float realSpeed;
    private float yawInput = 0f;
    private float pitchInput = 0f;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        teleportController = GetComponent<TeleportController>();

        joystick = GetComponentInChildren<XRJoystick>();
        if (joystick != null)
        {
            joystick.onValueChangeX.AddListener(OnJoystickYawChange);
            joystick.onValueChangeY.AddListener(OnJoystickPitchChange);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        teleportController.Initialize(trans);
        rb.isKinematic = false;
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.freezeRotation = true;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lastPosition = transform.position;

        if (!teleportController.IsTeleporting())
        {
            // 计算飞船与初始方向的夹角
            float angleWithInitial = Vector3.Angle(Vector3.right, trans.right);
            
            // 根据夹角决定是否需要反转俯仰输入
            float adjustedyawInput = angleWithInitial > 90f ? yawInput : -yawInput;

            // 计算每帧的旋转变化
            float pitchDelta = pitchInput * angularSpeed * Time.deltaTime;  // 俯仰（绕z轴）
            float yawDelta = adjustedyawInput * angularSpeed * Time.deltaTime;      // 偏航（绕y轴）
            
            // 应用旋转 - 只允许绕y轴（偏航）和z轴（俯仰）旋转
            // Quaternion targetRotation = Quaternion.Euler(0f, pitchDelta, yawDelta);
            // trans.rotation = Quaternion.Slerp(trans.rotation, targetRotation, angularSpeed * Time.deltaTime);
            trans.Rotate(0f, pitchDelta, yawDelta, Space.World);
            Vector3 currentEuler = trans.rotation.eulerAngles;
            trans.rotation = Quaternion.Euler(0f, currentEuler.y, currentEuler.z);
            
            // 更新速度方向

            // rb.velocity = transform.right * speed;
            trans.position += transform.right * speed * Time.deltaTime;

            if (teleportController.IsInTeleportMode())
            {
                teleportController.UpdateTeleportMarkerPosition();
            }
        }
        else
        {
            teleportController.MoveTowardsTeleportTarget();
        }
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    private void OnJoystickYawChange(float value)
    {
        yawInput = value;
    }

    private void OnJoystickPitchChange(float value)
    {
        pitchInput = -value;
    }

    private void OnDestroy()
    {
        if (joystick != null)
        {
            joystick.onValueChangeX.RemoveListener(OnJoystickYawChange);
            joystick.onValueChangeY.RemoveListener(OnJoystickPitchChange);
        }
    }

    public void ResetSpaceship()
    {
        rb.angularVelocity = Vector3.zero;
    }

    public void startTele()
    {
        if (!teleportController.IsInTeleportMode())
        {
            teleportController.EnterTeleportMode();
        }
        else if (!teleportController.IsTeleporting())
        {
            teleportController.StartTeleport();
        }
    }

    public void cancelTele()
    {
        if (teleportController.IsInTeleportMode())
        {
            teleportController.CancelTeleport();
        }
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
