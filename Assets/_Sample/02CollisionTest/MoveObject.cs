using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{

    public class MoveObject : MonoBehaviour
    {
        #region Variables
        private Rigidbody rb;

        //좌우이동
       [SerializeField] private float movePower = 5f;
        private float moveX;

        //색 변경
        private Material material;
        private Color originColor;
        #endregion


        void Start()
        {
          
            //참조
            rb = GetComponent<Rigidbody>();
            material = GetComponent<Renderer>().material;
            originColor = material.color;
            MoveRightByForce();
        }

        // Update is called once per frame
        void Update()
        {
            //입력 처리
            moveX = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            ////좌우로 힘을 주어 이동
            //
            //rb.AddForce(Vector3.right * moveX * movePower, ForceMode.Impulse);


        }

        public void MoveRightByForce()
        {
            rb.AddForce(Vector3.right * movePower, ForceMode.Force);
        }
        public void MoveLeftByForce()
        {
            rb.AddForce(Vector3.left * movePower, ForceMode.Force);
        }

        public void ChangeRedColor()
        {
            material.color = Color.red;
        }

        public void ResetColor()
        {
            material.color = originColor;
        }
    }

}