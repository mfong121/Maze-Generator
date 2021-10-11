using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FongMichael.Lab3
{
    public class WinCondition : MonoBehaviour
    {
        MazeRenderer mazeRenderer;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void initialize(MazeRenderer renderer)
        {
            mazeRenderer = renderer;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                mazeRenderer.win();
                Destroy(this.gameObject);
            }
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
