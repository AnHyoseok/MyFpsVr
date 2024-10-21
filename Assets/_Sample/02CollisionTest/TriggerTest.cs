using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MySample
{

    public class TriggerTest : MonoBehaviour
    {
 
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"TriggerEnter:{other.name}");
            //오른쪽으로 힘을준다
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if( moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ChangeRedColor();
            }
        }
        private void OnTriggerStay(Collider other)
        {

            Debug.Log($"TriggerStay:{other.name}");
        }
        private void OnTriggerExit(Collider other)
        {
         
            Debug.Log($"TriggerExit:{other.name}");
            //오른쪽으로 힘을준다
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ResetColor();
            }
        }
    }

}