using UnityEngine;

namespace FongMichael.Lab3
{
    public class CameraSwitcher : MonoBehaviour
    {
        [SerializeField] private Camera[] cameras;
        private int index = 0;
        // Start is called before the first frame update
        void Start()
        {
            index = 0;
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
            cameras[index].enabled = true;
        }

        public void NextCamera()
        {
            cameras[(index + 1) % cameras.Length].enabled = true;
            cameras[index % cameras.Length].enabled = false;
            index++;
        }
    }
}
