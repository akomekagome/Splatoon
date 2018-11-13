using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;
using UnityEngine.UI;

namespace Splatoon{
    
    public class Rank : MonoBehaviour {
        
        [SerializeField] private int number;
        private Text rankTexe;
        
        public int Number { get { return number; } }

        private void Awake()
        {
            rankTexe = this.GetComponent<Text>();
        }

        public void RankTextColorChange(Color color){
            rankTexe.color = color;
        }

        public void RankWrite(int rank)
        {
            rankTexe.text = rank.ToString("") + "位";
        }
    }
}
