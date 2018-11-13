using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Splatoon;

namespace Splatoon{
    public class Score : MonoBehaviour {

        [SerializeField] private int number;
        private Text scoreText;

        public int Number{ get { return number; }}

        private void Awake()
        {
            scoreText = this.GetComponent<Text>();
        }

        public void ScoreTextColorChange(Color color){
            scoreText.color = color;
        }
        public void SetScoreUI(int score){
            scoreText.text = score.ToString("");
        }
    }
}
