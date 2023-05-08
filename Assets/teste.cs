using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class teste : MonoBehaviour
{
    private PlayerControls gameControllerInput;

    void Awake()
    {
        gameControllerInput = new PlayerControls();
        gameControllerInput.GameController.Enable();
        gameControllerInput.GameController.EXIT.performed += EXIT;
        gameControllerInput.GameController.REESTART.performed += REESTART;
    }

    private void REESTART(InputAction.CallbackContext context)
    {
        Debug.Log("sCENA REINICIADA");
        SceneManager.LoadScene(0);
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
