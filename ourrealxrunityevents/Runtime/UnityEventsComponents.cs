using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace outrealxr.UnityEventsComponents
{ 
    public class UnityEventsComponents : MonoBehaviour
    {
        private static UnityEvent UnityEventOnTiggerEnter;
         public static UnityEvent TiggerEnterEvent { get => UnityEventOnTiggerEnter; set { UnityEventOnTiggerEnter = value; } }

        private static UnityEvent UnityEventOnTiggerExit;
         public static UnityEvent TiggerExitEvent { get => UnityEventOnTiggerExit; set { UnityEventOnTiggerExit = value; } }
    
        private static string TargetTagval;
        public static string TargetTag { get => TargetTagval; set { TargetTagval = value; } }


        
        // Start is called before the first frame update
        void Start()
        {
     
        }

        // Update is called once per frame
        void Update()
        {
             
        }
        public void OnTriggerEnter(Collider other)
        {
            Debug.LogError("other:" + other.gameObject.name);

            if(other.gameObject.tag==TargetTag)
            {
                TiggerEnterEvent.Invoke();
            }
        }
        public void OnTriggerExit(Collider other)
        {
            Debug.LogError("other:" + other.gameObject.name);
            if (other.gameObject.tag == TargetTag)
            {
                TiggerExitEvent.Invoke();
            }
        }

         
    }
}

