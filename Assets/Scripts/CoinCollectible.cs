using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FongMichael.Lab3
{
/*    [RequireComponent(typeof(Controller))]*/
    public class CoinCollectible : MonoBehaviour
    {

        [SerializeField]
        AudioSource audioSource;

        MazeRenderer mazeRenderer;

        Vector3 initPosition;
        float ySpeed;
        float maxDeltaY;
        float rotationSpeed = 100f;
        bool needPosition = true;
        bool pickup = false;

        // Start is called before the first frame update
        void Start()
        {
            /*            controller = GetComponent<Controller>();*/
           /* initPosition = this.transform.position;*/
            ySpeed = 0.05f;
            maxDeltaY = 0.05f;
        }

        public void initialize(MazeRenderer renderer)
        {
            mazeRenderer = renderer;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                mazeRenderer.addCoin();
                /*Debug.Log("You got a coin");*/
                StartCoroutine("Pickup");
            }
        }

        IEnumerator Pickup()
        {
            pickup = true;
            rotationSpeed *= 4;
            audioSource.Play();
            for (float ft = 1f; ft >= 0; ft -= 0.1f)
            {
                var renderer = this.GetComponent<Renderer>();

                this.transform.position += new Vector3(0, 3f * Time.deltaTime, 0); //bobbing up and down

                yield return new WaitForSeconds(.1f);
            }
            Destroy(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if (needPosition)
            {
                initPosition = this.transform.position;
                needPosition = false;
            }
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, this.transform.rotation * Quaternion.Euler(0, 0, rotationSpeed*Time.deltaTime),1); //coin rotation
            if (!pickup)
            {
                this.transform.position += new Vector3(0, ySpeed * Time.deltaTime, 0); //bobbing up and down
            }
                float deltaY = this.transform.position.y - initPosition.y;
            if (deltaY > maxDeltaY|| deltaY < -maxDeltaY)
            {
                ySpeed *= -1f;
            }
        }
    }
}
