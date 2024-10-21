using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{

    public class CollsionTest : MonoBehaviour
    {
       

        private void OnCollisionEnter(Collision collision)
        {
         
            Debug.Log($"CollersionEnter:{collision.gameObject.name}");
            //왼쪽으로 힘을준다
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
         
            if (moveObject != null)
            {
                moveObject.MoveLeftByForce();
                moveObject.ChangeRedColor();
            }
        }
        private void OnCollisionStay(Collision collision)
        {
            Debug.Log($"CollersionStay:{collision.gameObject.name}");
        }

        private void OnCollisionExit(Collision collision)
        {
          
            Debug.Log($"CollersionExit:{collision.gameObject.name}");
            //왼쪽으로 힘을준다
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
            moveObject.ResetColor();
            if (moveObject != null)
            {
                moveObject.MoveLeftByForce();
                moveObject.ResetColor();
            }

        }
    }

}