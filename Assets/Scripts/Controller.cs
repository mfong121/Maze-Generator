using UnityEngine;
using FongMichael.Lab3.Input;
using UnityEngine.InputSystem;

namespace FongMichael.Lab3
{

    public class Controller : MonoBehaviour
    {
        public bool rotationOn = false;
        [SerializeField]
        [Range(0, 1f)]
        float rotationSpeed;

        [SerializeField]
        MazeRenderer mazeRenderer;

        [SerializeField]
        CameraSwitcher cameraSwitcher;

        [SerializeField]
        MovementController movementController;

        [SerializeField]
        CharacterCamera characterCamera;

        private ControlScheme inputScheme;
 

        // Start is called before the first frame update
        void Awake()
        {
            inputScheme = new ControlScheme();
        }

        // Update is called once per frame
        void OnEnable()
        {
            var _ = new QuitHandler(inputScheme.Controls.Quit);
            var nextCameraHandler = new NextCameraHandler(inputScheme.Controls.SwapCamera,cameraSwitcher);
            inputScheme.Controls.ToggleRotation.performed += toggleRotatePerformed;
            inputScheme.Controls.ToggleRotation.Enable();

            movementController.initialize(mazeRenderer, inputScheme.Controls.MovePlayer, inputScheme.Controls.Sprint);
            characterCamera.initialize(inputScheme.Controls.RotatePlayerCamera);
        }

        private void OnGUI()
        {
            //0 for rotating maze
            GUI.Label(new Rect(20, 20, 300, 300), "Controls:\nESC to quit\nC to swap cameras\nWASD, Arrow keys, or Left Stick to move\nSHIFT to sprint");
            GUI.Label(new Rect(Screen.width-100, 20, 50, 50), "Score: " + mazeRenderer.getCoins());
        }

        void toggleRotatePerformed(InputAction.CallbackContext obj)
        {
           /*rotationOn = !rotationOn;*/ //disable rotation for lab3
        }

        void Update()
        {
            if (rotationOn)
            {
                mazeRenderer.transform.Rotate(new Vector3(0,rotationSpeed,0));
            }
        }

/*        public void win()
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 100, 100), "Game Over:\nYou caught Richard Parker!\nYou had a final score of " + mazeRenderer.getCoins() + ".");
        }*/
    }
}
