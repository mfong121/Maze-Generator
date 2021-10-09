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

        }
    }
}
