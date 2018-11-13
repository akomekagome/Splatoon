using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    public class Move : MonoBehaviour {
        
        //private float? jumpAfterDif = null;
        
        private Rigidbody rb;
        [SerializeField] private float speed = 200f;
        private Vector3 moveVec;
        private Animator playerAnimator;
        [SerializeField]private float rotateSpeed = 2f;
        [SerializeField]private float jumpPower = 200f;
        private bool canJump = false;
        private bool canMove = false;
        private bool hasPushedButton = false;
        private int number;
        private float v, h;

        public bool CanMove{ set { canMove = value; }}
        public int Number{ set { number = value; }}

        public Action AnimationEnd;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<Animator>();
            AnimationEnd = () => playerAnimator.Play("idel", 0, 0.0f);
        }

        public void PlayerUqdate(){
            JoyconJumpJudge();
            //KeyBordJumpJudge();
            AnimationChange();
            Rotaion();
        }

        private void FixedUpdate()
        {
            if(canMove){
                JoyconMove();
                //KeyBordMove();
                Jump();

            }
        }

        private void JoyconJumpJudge(){
            if(JoyconController.Instance.PusedDownButtonDownSide(number)){
                hasPushedButton = true;
            }
        }

        private void KeyBordJumpJudge()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hasPushedButton = true;
            }
        }

        private void JoyconMove(){
            v = JoyconController.Instance.Vertical(number);
            h = JoyconController.Instance.Horizontal(number);
            moveVec = new Vector3(h, 0, v).normalized * speed * Time.deltaTime;
            moveVec.y = rb.velocity.y;
            rb.velocity = moveVec;
        }

        private void KeyBordMove(){
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            moveVec = new Vector3(h, 0, v).normalized * speed * Time.deltaTime;
            moveVec.y = rb.velocity.y;
            rb.velocity = moveVec;
        }

        private void Jump(){
            if(hasPushedButton && canJump){
                canJump = false;
                hasPushedButton = false;
                var animatorInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
                if(animatorInfo.IsName("Base Layer.Jump"))return;
                rb.AddForce(Vector3.up * jumpPower);
            }
        }

        private void OnCollisionEnter(Collision c)
        {
            if (c.gameObject.GetComponent<Tile>() != null)canJump = true;
        }

        //private bool JumpJudge(){
        //    var jumpRay = new Ray(transform.position, Vector3.down);
        //    RaycastHit hit;
        //    if (Physics.Raycast(jumpRay, out hit))
        //    {
        //        if (hit.transform.GetComponent<Tile>() == null) return false;
        //        var jumpDif = transform.position.y - hit.transform.position.y;
        //        Debug.Log(jumpDif);
        //        if (jumpDif == jumpAfterDif || jumpAfterDif == null){
        //            Debug.Log(jumpAfterDif);
        //            jumpAfterDif = jumpDif;
        //        }
        //        else return false;
        //        return true;
        //    }
        //    else { return false; }
        //}

        private void Rotaion(){
            moveVec.y = 0;
            var playerDir = Vector3.RotateTowards(transform.forward, moveVec, rotateSpeed * Time.deltaTime, 0f);
            if (moveVec.magnitude != 0) transform.rotation = Quaternion.LookRotation(playerDir);
        }

        private void AnimationChange(){
            if (v != 0 || h != 0) playerAnimator.SetBool("Walk", true);
            else playerAnimator.SetBool("Walk", false);

            if (!canJump) playerAnimator.SetBool("Jump", true);
            else playerAnimator.SetBool("Jump", false);
        }

    }
}
