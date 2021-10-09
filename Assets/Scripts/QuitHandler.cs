using UnityEngine;
using UnityEngine.InputSystem;

namespace FongMichael.Lab3
{
    public class QuitHandler
    {
        public QuitHandler(InputAction quitAction)
        {
            quitAction.performed += QuitAction_performed;
            quitAction.Enable();
        }
        private void QuitAction_performed(InputAction.CallbackContext obj_)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
