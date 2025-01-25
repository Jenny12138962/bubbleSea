using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    private SpaceCraftController spaceCraftController;
    void Awake()
    {
        spaceCraftController = GetComponent<SpaceCraftController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            spaceCraftController.StartCoroutine(spaceCraftController.PauseMovement());
        }
    }
}
