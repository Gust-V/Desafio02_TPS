using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class sPlayerController : MonoBehaviour
{
    //Valores serializados para poder realizar alterações na unity para testes
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotSpeed = 5f;

    private CharacterController controller; //Controller recebe o Character Controller no Start
    private PlayerInput plInput; //Vai receber o Player Input no Start
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform camTransf; //Vai pegar o transform da câmera principal

    //Recebem as Actions estabelecidas no Input Editor
    private InputAction moveact;
    private InputAction jumpact;
    private InputAction lookkact;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        plInput = GetComponent<PlayerInput>();
        camTransf = Camera.main.transform;

        moveact = plInput.actions["MOVE"];
        lookkact = plInput.actions["LOOK"];
        jumpact = plInput.actions["JUMP"];
    }

    private void Awake()
    {
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }

    void Update()
    {
        groundedPlayer = controller.isGrounded; //Verifica se o player está tocando o chão no último movimento
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        /*var gamepad = Gamepad.current;

        if (gamepad.added == true)
        {
            Vector2 inputMy = gamepad.leftStick.ReadValue();
            Vector3 move = new Vector3(inputMy.x, 0, inputMy.y);
            move = move.x * camTransf.right.normalized + move.z * camTransf.forward.normalized; //Vai direcionar de acordo com o tranform da câmera principal
            move.y = 0; //Pode causa alguns bugs se não definir igual a zero
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (jumpact.triggered && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }*/
        else
        {
            Vector2 inputMy = moveact.ReadValue<Vector2>();
            Vector3 move = new Vector3(inputMy.x, 0, inputMy.y);
            move = move.x * camTransf.right.normalized + move.z * camTransf.forward.normalized; //Vai direcionar de acordo com o tranform da câmera principal
            move.y = 0; //Pode causa alguns bugs se não definir igual a zero
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (jumpact.triggered && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

        //Vector2 inputMy = moveact. ReadValue<Vector2>();
        /* Vector3 move = new Vector3(inputMy.x, 0, inputMy.y);
         move = move.x * camTransf.right.normalized + move.z * camTransf.forward.normalized; //Vai direcionar de acordo com o tranform da câmera principal
         move.y = 0; //Pode causa alguns bugs se não definir igual a zero
         controller.Move(move * Time.deltaTime * playerSpeed);

         // Changes the height position of the player..
         if (jumpact.triggered && groundedPlayer)
         {
             playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
         }

         playerVelocity.y += gravityValue * Time.deltaTime;
         controller.Move(playerVelocity * Time.deltaTime);*/

        //Rotaciona de acordo com a direção da câmera
        Quaternion targetRotation = Quaternion.Euler(0, camTransf.eulerAngles.y, 0); //O personagem rotaciona em torno do eixo Y
        this.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }
}