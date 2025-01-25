using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    private SubmachineController submachineController;
    void Awake()
    {
        submachineController = GetComponent<SubmachineController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.ToString());
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            submachineController.StartCoroutine(submachineController.PauseMovement());
        }
    }
}
