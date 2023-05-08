using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class sPlayerController_02 : MonoBehaviour
{
    //Valores de fisica e movimentação
    //[SerializeField]
    private float playerSpeed = 3.0f;
    //[SerializeField]
    private float jumpHeight = 1.0f;
    //[SerializeField]
    private float gravityValue = -9.81f;
    //[SerializeField]
    private float rotSpeed = 100f;
    //[SerializeField]
    private float playerAceleret = 0.0f;

    //[SerializeField]
    public int currentHP = 100;
    //[SerializeField]
    public int maxHP = 100;

    private CharacterController controller; //Controller recebe o Character Controller no Start
    private PlayerInput playerInput; //Vai receber o Player Input no Start

    private Transform camTransf;
    private PlayerControls playerInpAct;
    private GameObject actualGun;
    private sRigidBodyPlayer rbPlayer;
    private RaycastHit hitObj;
    private Vector3 playerVelocity;

    public bool isGraunded = false;
    private bool isRunning = false;
    private bool isMoving = false;
    private bool isKneel = false;

    public Animator _animator;
    private int _animIDSpeed;
    private int _animIDGrounded;
    private int _animIDJump;
    private int _animIDKneel;
    private int _animIDFreeFall;
    private int _animIDMotionSpeed; 
    private float _animationBlend;
    public float SpeedChangeRate = 10.0f;

    private bool objOn = false;
    private Vector3 stayPosition = new Vector3();


    private float groundCheckDistance;
    private float collectableCheckDistance;
    private float bufferCheckDistance = 1.0f;

    private void Awake()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDGrounded = Animator.StringToHash("Grounded");
        _animIDJump = Animator.StringToHash("Jump");
        _animIDFreeFall = Animator.StringToHash("FreeFall");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        _animIDKneel = Animator.StringToHash("inKneel");

        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        camTransf = Camera.main.transform;

        rbPlayer = this.transform.GetChild(2).gameObject.GetComponent<sRigidBodyPlayer>();

        playerInpAct = new PlayerControls();
        playerInpAct.PlayerController.Enable();

        Cursor.lockState = CursorLockMode.Locked;

        AddActionPerformed();
        
        //playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void Update()
    {
        actualGun = this.transform.GetChild(0).GetComponent<sChangeGun>().activeGun;

        CheckEnemy();
        
        if (isGraunded == true && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        CheckCollectable();
        CheckGround(); //A POHA DO CONTROLLER.ISGROUNDED NÃO FUNCIONAAAAAAAAAAAAAA, vamo de raycast

        stayPosition = controller.transform.position; //Posição ""inicial", quando está "parado"

        MovePlayer();
        
    }

    private void MovePlayer()
    {
        //Movimentação
        Vector2 inputVector = playerInpAct.PlayerController.MOVE.ReadValue<Vector2>();
        Vector3 move = new Vector3(inputVector.x, 0, inputVector.y);
        move = move.x * camTransf.right.normalized + move.z * camTransf.forward.normalized;
        move.y = 0;

        _animationBlend = Mathf.Lerp(_animationBlend, playerAceleret, Time.deltaTime * SpeedChangeRate);
        if (_animationBlend < 0.01f) _animationBlend = 0f;

        controller.Move(move * playerSpeed * Time.deltaTime);


        //Valida se permanece parado ou se moveu
        if (controller.transform.position != stayPosition)
        {
            if(isKneel == true)
            {
                isKneel = false;
                _animator.SetBool(_animIDKneel, false);
                var cinemachineBrain = playerInput.camera.GetComponent<sCinemachineBrain>();
                cinemachineBrain.kneel(false);
                Vector3 actPosition = transform.GetChild(0).gameObject.transform.position;
                transform.GetChild(0).gameObject.transform.position = new Vector3(actPosition.x, actPosition.y + 0.4f, actPosition.z);
            }
            isMoving = true;
            playerAceleret = playerSpeed;
        }
        else
        {
            isMoving = false;
            playerAceleret = 0;
        }
        _animator.SetFloat(_animIDSpeed, _animationBlend);
        _animator.SetFloat(_animIDMotionSpeed, 1);
        /*if(isMoving == true)
        {
            _animator.SetFloat(_animIDSpeed, _animationBlend);
            _animator.SetFloat(_animIDMotionSpeed, 1);
        }
        else
        {
            _animator.SetFloat(_animIDSpeed, _animationBlend);
            _animator.SetFloat(_animIDMotionSpeed, 0);
        }*/

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        Quaternion targetRotation = Quaternion.Euler(0, camTransf.eulerAngles.y, 0); //O personagem rotaciona em torno do eixo Y
        this.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }
    private void CHANGE_GUNS_NUM_DIREC(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        gameObject.transform.GetChild(0).GetComponent<sChangeGun>().MenuGun(value.x, value.y);
    }

    private void CHANGE_GUNSWHEEL(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        gameObject.transform.GetChild(0).GetComponent<sChangeGun>().ChangeGuns(value.y);
        
    }

    private void CHANGE_GUNSGAMEPAD(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        gameObject.transform.GetChild(0).GetComponent<sChangeGun>().ChangeGuns(value);
    }

    private void RELOAD(InputAction.CallbackContext context)
    {
        if (actualGun.GetComponent<sGun01>())
        {
            actualGun.GetComponent<sGun01>().Reloading();
        }
        else if (actualGun.GetComponent<sGun02>())
        {
            actualGun.GetComponent<sGun02>().Reloading();
        }
        else if (actualGun.GetComponent<sGun03>())
        {
            actualGun.GetComponent<sGun03>().Reloading();
        }
        else if (actualGun.GetComponent<sGun04>())
        {
            actualGun.GetComponent<sGun04>().Reloading();
        }

    }

    private void SHOOT(InputAction.CallbackContext context)
    {
        if (isGraunded == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(camTransf.position, camTransf.forward, out hit, Mathf.Infinity, 7 << LayerMask.NameToLayer("Enemy")) ||
               Physics.Raycast(camTransf.position, camTransf.forward, out hit, Mathf.Infinity, 3 << LayerMask.NameToLayer("Cenario")))
            {
                int targeType = hit.transform.gameObject.layer;
                if (actualGun.GetComponent<sGun01>())
                {
                    actualGun.GetComponent<sGun01>().isShotting(hit, true, camTransf, targeType);
                }
                else if (actualGun.GetComponent<sGun02>())
                {
                    actualGun.GetComponent<sGun02>().isShotting(hit, true, camTransf, targeType);
                }
                else if (actualGun.GetComponent<sGun03>())
                {
                    actualGun.GetComponent<sGun03>().isShotting(hit, true, camTransf, targeType);
                }
                else if (actualGun.GetComponent<sGun04>())
                {
                    actualGun.GetComponent<sGun04>().isShotting(hit, true, camTransf, targeType);
                }
            }
            else
            {
                if (actualGun.GetComponent<sGun01>())
                {
                    actualGun.GetComponent<sGun01>().isShotting(hit, false, camTransf, 0);
                }
                else if (actualGun.GetComponent<sGun02>())
                {
                    actualGun.GetComponent<sGun02>().isShotting(hit, false, camTransf, 0);
                }
                else if (actualGun.GetComponent<sGun03>())
                {
                    actualGun.GetComponent<sGun03>().isShotting(hit, false, camTransf, 0);
                }
                else if (actualGun.GetComponent<sGun04>())
                {
                    actualGun.GetComponent<sGun04>().isShotting(hit, false, camTransf, 0);
                }
            }

        }
    }

    private void SQUAT(InputAction.CallbackContext context)
    {
        var cinemachineBrain = playerInput.camera.GetComponent<sCinemachineBrain>();
        if (isKneel == false)
        {
            isKneel = true;
            _animator.SetBool(_animIDKneel, true);
            Vector3 actPosition = transform.GetChild(0).gameObject.transform.position;
            transform.GetChild(0).gameObject.transform.position = new Vector3(actPosition.x, actPosition.y - 0.4f, actPosition.z);
            cinemachineBrain.kneel(true);
            //cinemachineBrain.yTrackCam = 1.1f; 
        }
        else if (isKneel == true)
        {
            isKneel = false;
            _animator.SetBool(_animIDKneel, false);
            Vector3 actPosition = transform.GetChild(0).gameObject.transform.position;
            transform.GetChild(0).gameObject.transform.position = new Vector3(actPosition.x, actPosition.y + 0.4f, actPosition.z);
            cinemachineBrain.kneel(false);
            //cinemachineBrain.yTrackCam = 1.5f;
        }
    }

    private void INTERACTION(InputAction.CallbackContext context)
    {
        if (objOn == true)
        {
            if(hitObj.transform.tag == "Life_Collectable")
            {
                if (currentHP >= maxHP)
                {
                   Debug.Log("Full Hp");
                }
                else
                {
                    Destroy(hitObj.transform.gameObject);
                    currentHP = currentHP + 20;
                    if(currentHP > 100)
                    {
                        currentHP = 100;
                    }
                }
            }
        }
    }

    private void AIM(InputAction.CallbackContext context)
    {
        var cinemachineBrain = playerInput.camera.GetComponent<sCinemachineBrain>();
        if (context.performed && isRunning == false)
        {
            cinemachineBrain.OnAim(true);
        }
        else if (context.canceled)
        {
            cinemachineBrain.OnAim(false);
        }
    }

    private void JUMP(InputAction.CallbackContext context)
    {
        
        if (isGraunded == true)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            controller.Move(playerVelocity * Time.deltaTime);
            _animator.SetBool(_animIDJump, true);
        }
    }

    private void RUN(InputAction.CallbackContext context)
    {
        if (context.performed && isGraunded == true && isMoving == true)
        {
            var cinemachineBrain = playerInput.camera.GetComponent<sCinemachineBrain>();
            cinemachineBrain.OnAim(false);
            isRunning = true;
            playerSpeed = 6.0f;
            playerAceleret = playerSpeed;
        }
        else if (context.canceled)
        {
            isRunning = false;
            playerSpeed = 3.0f;
            playerAceleret = 0;
        }
    }

    private void CheckEnemy()
    {
        var cinemachineBrain = playerInput.camera.GetComponent<sCinemachineBrain>();
        RaycastHit hit;
        if(Physics.Raycast(camTransf.position, camTransf.forward, out hit, Mathf.Infinity, 7 << LayerMask.NameToLayer("Enemy")))
        {
            cinemachineBrain.isInEnemy = true;
        }
        else
        {
            cinemachineBrain.isInEnemy = false;
        }
    }

    private void CheckGround()
    {
        //groundCheckDistance = (GetComponent<CapsuleCollider>().height / 10) + bufferCheckDistance;
        //Debug.Log(groundCheckDistance);
        Vector3 postion = new Vector3(transform.position.x, transform.position.y + bufferCheckDistance, transform.position.z);

        RaycastHit hit;
        Debug.DrawRay(postion, -transform.up * bufferCheckDistance, Color.red);
        if(Physics.Raycast(postion, -transform.up, out hit, bufferCheckDistance))
        {
            isGraunded = true;
            _animator.SetBool(_animIDGrounded, isGraunded);
            _animator.SetBool(_animIDJump, false);
            _animator.SetBool(_animIDFreeFall, false);
        }
        else
        {
            isGraunded = false;
            _animator.SetBool(_animIDGrounded, isGraunded);
        }
    }

    private void CheckCollectable()
    {
        collectableCheckDistance = (GetComponent<CapsuleCollider>().radius * 4) + bufferCheckDistance;

        if (Physics.Raycast(transform.position, this.gameObject.transform.TransformDirection(Vector3.forward), out hitObj, collectableCheckDistance))
        {
            objOn = true;
        }
        else
        {
            objOn = false;
        }
    }

    private void AddActionPerformed()
    {
        //Associa a ação de pular quando o botão é pressionado a função JUMP
        playerInpAct.PlayerController.JUMP.performed += JUMP;

        //Associa a ação de correr quando o botão é pressionado a função RUN. Associa também quando ela é 'cancelada"/para de pressionar o botão
        playerInpAct.PlayerController.RUN.performed += RUN;
        playerInpAct.PlayerController.RUN.canceled += RUN;

        //Associa a ação de mirar quando o botão é pressionado a função AIM
        playerInpAct.PlayerController.AIM.performed += AIM;
        playerInpAct.PlayerController.AIM.canceled += AIM;

        //Associa a ação de interação quando o botão é pressionado a função INTERACTION
        playerInpAct.PlayerController.INTERACTION.performed += INTERACTION;

        playerInpAct.PlayerController.SQUAT.performed += SQUAT;

        playerInpAct.PlayerController.SHOOT.performed += SHOOT;

        playerInpAct.PlayerController.RELOAD.performed += RELOAD;


        playerInpAct.PlayerController.CHANGE_GUNSWHEEL.performed += CHANGE_GUNSWHEEL;

        playerInpAct.PlayerController.CHANGE_GUNSGAMEPAD.performed += CHANGE_GUNSGAMEPAD;

        playerInpAct.PlayerController.CHANGE_GUNS_NUM_DIREC.performed += CHANGE_GUNS_NUM_DIREC;

        playerInpAct.PlayerController.LOOK.performed += LOOK; 
        playerInpAct.PlayerController.LOOK.canceled += LOOK;
        playerInpAct.PlayerController.LOOK.started += LOOK;
    }

    private void LOOK(InputAction.CallbackContext context)
    {
        var cinemachineBrain = playerInput.camera.GetComponent<sCinemachineBrain>();
        if (context.control.name == "rightStick")
        {
            cinemachineBrain.speed(1f);
        }
        else
        {
            cinemachineBrain.speed(0.2f);
        }
        Debug.Log(context.control.name) ;
    }
}
