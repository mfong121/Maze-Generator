using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FongMichael.Lab3
{
    public class CharacterCamera : MonoBehaviour
    {

        [SerializeField]
        GameObject character;
        [SerializeField]
        Camera characterCamera;
        // Start is called before the first frame update

        InputAction rotatePlayerCameraAction;

        Vector2 oldMousePos, newMousePos, deltaMousePos;

        public void initialize(InputAction rotatePlayerCameraAction)
        {
            rotatePlayerCameraAction.Enable();
            this.rotatePlayerCameraAction = rotatePlayerCameraAction;
        }


        void Start()
        {
            characterCamera.transform.position = character.transform.position;
            rotatePlayerCameraAction.performed += rotatePlayerCameraActionPerformed;
        }

        // Update is called once per frame
        void Update()
        {
           characterCamera.transform.position = character.transform.position;
        }


        public void rotatePlayerCameraActionPerformed(InputAction.CallbackContext obj)
        {

            oldMousePos = newMousePos;
            
            newMousePos = rotatePlayerCameraAction.ReadValue<Vector2>();
            deltaMousePos = newMousePos - oldMousePos;

            character.transform.rotation = Quaternion.RotateTowards(character.transform.rotation, character.transform.rotation * Quaternion.Euler(0, deltaMousePos.x, 0), 360);
            characterCamera.transform.Rotate(-deltaMousePos.y, deltaMousePos.x, 0);
            Vector3 currentAngles = characterCamera.transform.rotation.eulerAngles;
            characterCamera.transform.rotation = Quaternion.Euler(currentAngles.x, character.transform.rotation.eulerAngles.y, 0);
            
            /*Debug.Log("yDegree: " + yDegree);*/
        }
    }
}
