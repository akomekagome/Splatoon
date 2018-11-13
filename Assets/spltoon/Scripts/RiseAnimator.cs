using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    public class RiseAnimator : StateMachineBehaviour {
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<Damage>().riseEnd();
        }
    }
    
}