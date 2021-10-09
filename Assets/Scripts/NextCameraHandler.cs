using UnityEngine.InputSystem;


namespace FongMichael.Lab3
{
    public class NextCameraHandler
    {
        CameraSwitcher camera_switcher;
        public NextCameraHandler(InputAction swapCameraAction, CameraSwitcher camera_switcher)
        {
            this.camera_switcher = camera_switcher;
            swapCameraAction.performed += swapCamera_performed;
            swapCameraAction.Enable();
        }

        private void swapCamera_performed(InputAction.CallbackContext obj)
        {
            camera_switcher.NextCamera();
        }
    }
}
