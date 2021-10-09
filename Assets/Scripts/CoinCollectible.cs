using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FongMichael.Lab3
{
/*    [RequireComponent(typeof(Controller))]*/
    public class CoinCollect : MonoBehaviour
    {
/*        Controller controller;*/
        
        // Start is called before the first frame update
        void Start()
        {
/*            controller = GetComponent<Controller>();*/
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
/*                controller.addCoin();*/
                Debug.Log("You got a coin");
            }
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
