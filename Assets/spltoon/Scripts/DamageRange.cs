using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class DamageRange : MonoBehaviour{
        
        public Action hitNotices;
        public Func<Vector3> setgetPos; 
    }
}
