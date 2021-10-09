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

        private int numCoins = 0;
 

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
            GUI.Label(new Rect(20, 20, 300, 300), "Controls:\nESC to quit\nC to swap cameras\n0 to rotate maze");
        }

        void toggleRotatePerformed(InputAction.CallbackContext obj)
        {
           rotationOn = !rotationOn;
        }

        void Update()
        {
            if (rotationOn)
            {
                mazeRenderer.transform.Rotate(new Vector3(0,rotationSpeed,0));
            }
        }

        public void addCoin()
        {
            numCoins++;
            Debug.Log("Coins collected: " + numCoins);
        }
    }
}
