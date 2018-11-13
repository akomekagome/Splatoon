using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class Damage : MonoBehaviour {
        
        private Animator animator;
        [SerializeField] private float damageRange = 0.5f;
        [SerializeField] private DamageRange damageRangeObj;
        [SerializeField] private SkinnedMeshRenderer playerMeshRender;
        //private bool hasDowned = false;
        private bool hasinvincibled = false;
        private Rigidbody rb;
        private List<SkinnedMeshRenderer> PlayerMeshRenders;
        private Vector3 startPos;
        private int number;

        public Action<bool, int> setCanMove;
        public Action riseEnd;

        public int Number{ set { number = value; }}
        public DamageRange GetDamageRange { get { return damageRangeObj; } }


        private void Start()
        {
            startPos = transform.position;

            PlayerMeshRenders = new List<SkinnedMeshRenderer>();

            foreach (Transform child in transform)
            {
                var playerMeshRender = child.GetComponent<SkinnedMeshRenderer>();
                if (playerMeshRender != null) PlayerMeshRenders.Add(playerMeshRender);
            }

            PlayerMeshRenders.Add(this.playerMeshRender);

            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            damageRangeObj.hitNotices += () => Down();
            riseEnd = () => { DownProcess(false); StartCoroutine(Flash(4f)); };
        }

        private void Update()
        {
            if(transform.position.y <=  -30f){
                transform.position = startPos;
                hasinvincibled = true;
                StartCoroutine(Flash(3f));
            }
        }

        private void Down(){
            if (hasinvincibled) return;
            animator.Play("Down", 0, 0.0f);
            var lookPos = damageRangeObj.setgetPos() - transform.position;
            transform.rotation = Quaternion.LookRotation(lookPos);
            StartCoroutine(DownWait());
        }
        
        IEnumerator DownWait(){
            hasinvincibled = true;
            DownProcess(true);
            yield return new WaitForSeconds(3.0f);
            animator.SetTrigger("Rise");
        }

        IEnumerator Flash(float time){
            while(time >= 0){
                foreach(var mr in PlayerMeshRenders){
                    mr.enabled = !mr.enabled;
                }
                time -= 0.2f;
                yield return new WaitForSeconds(0.2f);
            }
            foreach(var mr in PlayerMeshRenders){
                mr.enabled = true;
            }
            hasinvincibled = false;
        }

        private void DownProcess(bool enable){
            rb.isKinematic = enable;
            if (setCanMove != null) setCanMove(!enable, number);
        }
    }
}