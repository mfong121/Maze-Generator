using UnityEngine;
using UnityEngine.InputSystem;


namespace FongMichael.Lab3
{
    public class MovementController: MonoBehaviour
    {

        [SerializeField]
        private GameObject characterToMove;
        [SerializeField]
        [Range(1,3)]
        private float moveSpeed;

        [SerializeField]
        [Range(1.5f,4)]
        private float sprintSpeedMultiplier;

        [SerializeField]
        CharacterCamera characterCamera;

        private Vector2 movementVector;

        private InputAction movePlayerAction, sprintAction;
        private MazeRenderer mazeRenderer;
        public void initialize(MazeRenderer mazeRenderer, InputAction movePlayerAction, InputAction sprintAction)
        {
            this.mazeRenderer = mazeRenderer;

            movePlayerAction.Enable();

            sprintAction.Enable();

            this.movePlayerAction = movePlayerAction;
            
            this.sprintAction = sprintAction;

         
        }
        // Start is called before the first frame update
        void Start()
        {
            movePlayerAction.performed += movePlayerActionPerformed;
            movePlayerAction.canceled += movePlayerActionCancelled;

            sprintAction.started += sprintPlayerActionStarted;
            sprintAction.canceled += sprintPlayerActionCancelled;

            characterToMove.transform.position = new Vector3(-mazeRenderer.width*mazeRenderer.cellSize/2 + mazeRenderer.cellSize/2,1,-mazeRenderer.height*mazeRenderer.cellSize/2+mazeRenderer.cellSize/2);
                /*-width*cellSize / 2 + i*cellSize+cellSize/2, 1, -height*cellSize / 2 + j*cellSize+cellSize/2*/
        }

        // Update is called once per frame
        void Update()
        {
            /*            characterToMove.transform.localPosition += new Vector3(movementVector.x * Time.deltaTime * moveSpeed, 0, movementVector.y * Time.deltaTime * moveSpeed); */
            Vector3 currentPos = characterToMove.transform.localPosition;
            Vector2 currentMoveAction = movePlayerAction.ReadValue<Vector2>();
            
            Vector3 desiredDirection = currentMoveAction.y*characterToMove.transform.forward + currentMoveAction.x*characterToMove.transform.right;


            characterToMove.transform.localPosition = Vector3.MoveTowards(currentPos, currentPos + desiredDirection, moveSpeed * Time.deltaTime);
        }
        
        public void movePlayerActionPerformed(InputAction.CallbackContext obj)
        {
            movementVector = movePlayerAction.ReadValue<Vector2>();
            /*            movementVector = Vector3.MoveTowards(characterToMove.transform.position,characterToMove.transform.position.,moveSpeed*Time.delta)*/
            movementVector = characterToMove.transform.forward * movementVector.y * moveSpeed + characterToMove.transform.right * movementVector.x * moveSpeed;

            Debug.Log("MovePlayerAction.ReadValue: " + movePlayerAction.ReadValue<Vector2>());
/*            Debug.Log("characterToMove.Transform.right: " + characterToMove.transform.right);
*/            Debug.Log("characterToMove.Transform.forward: " + characterToMove.transform.forward);

        }

        public void movePlayerActionCancelled(InputAction.CallbackContext obj)
        {
            movementVector *= 0;
        }



        public void sprintPlayerActionStarted(InputAction.CallbackContext obj)
        {
            moveSpeed *= sprintSpeedMultiplier;
/*            Debug.Log("Sprinting");
*/        }

        public void sprintPlayerActionCancelled(InputAction.CallbackContext obj)
        {
            moveSpeed /= sprintSpeedMultiplier;
/*            Debug.Log("Walking");
*/        }
    }
}
