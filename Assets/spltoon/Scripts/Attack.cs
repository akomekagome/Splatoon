using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class Attack : MonoBehaviour {
        
        [SerializeField] private float attackRange = 0.5f;
        private Animator animator;
        [SerializeField] private AttackRange attackRangeObj;
        private bool canPanch = true;
        private AudioSource audioSource;
        [SerializeField] private AudioClip panchSound;
        private int number;

        public int Number{ set { number = value; }}

        void Start () {
            animator = GetComponent<Animator>();
            attackRangeObj.GetComponent<SphereCollider>().radius = attackRange;
            attackRangeObj.gameObject.SetActive(false);
            var damage = GetComponent<Damage>();
            if (damage == null) { Debug.Log("null"); return; }

            attackRangeObj.compare += damagrange => damagrange == damage.GetDamageRange;
            attackRangeObj.sendPos += () => transform.position;
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayerUpdate(){
            //KeyBordAttack();
            JoyconAttack();
        }

        public void KeyBordAttack(){
            if(Input.GetKeyDown(KeyCode.Z) && canPanch){
                AttackProcess();
            }
        }

        public void JoyconAttack(){
            if(JoyconController.Instance.PusedRightButtonDownSide(number) && canPanch){
                AttackProcess();
            }
        }

        private void AttackProcess(){
            var animatorInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (animatorInfo.IsName("Base Layer.Jump")) return;
            canPanch = false;
            audioSource.PlayOneShot(panchSound);
            animator.SetTrigger("Attack");
            StartCoroutine(Wait());
        }
        public void StateChange(bool active){
            attackRangeObj.gameObject.SetActive(active);
        }

        IEnumerator Wait(){
            yield return new WaitForSeconds(0.5f);
            canPanch = true;
        }
    }
}