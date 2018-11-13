using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class AttackRange : MonoBehaviour {
        
        public Func<DamageRange, bool> compare;
        public Func<Vector3> sendPos;

        private void OnTriggerEnter(Collider other)
        {
            DamageRange hitedPlayer = other.GetComponent<DamageRange>();

            //擬似的なタグ検索
            if(hitedPlayer != null){
                if (compare == null) { Debug.Log("null"); return; }
                if(!compare(hitedPlayer)){
                    hitedPlayer.setgetPos = () => { return sendPos(); };
                    hitedPlayer.hitNotices();
                }
            } 
        }
    }
    
}