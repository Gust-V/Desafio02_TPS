using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class sGameController : MonoBehaviour
{
    private PlayerControls gameControllerInput;

    void Awake()
    {
        gameControllerInput = new PlayerControls();
        gameControllerInput.GameController.Enable();
        gameControllerInput.GameController.EXIT.performed += EXIT;
    }

    private void EXIT(InputAction.CallbackContext context)
    {
        Debug.Log("ENCERRADA");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
