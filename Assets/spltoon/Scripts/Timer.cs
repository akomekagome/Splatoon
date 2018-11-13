using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Splatoon;

namespace Splatoon{
    
    public class Timer : MonoBehaviour
    {
        
        private Text timerText;
        //現在のタイムを保持するための変数
        [SerializeField] private float totalTime = 60f;
        
        //色
        //シリアライズフィールドを使うとなぜかエラーを吐きます
        private Color darkGreen;
        private Color rightGreen;
        private Color yellow;
        private Color orange;
        private Color redOrange;
        private Color red;
        
        public float TotalTime { get { return totalTime; } }
        
        public Action End;
        
        // Use this for initialization
        void Start()
        {
            timerText = GetComponent<Text>();
            
            //色の取得
            darkGreen = new Color(15f / 255f, 166f / 225f, 66f / 255f);
            rightGreen = new Color(81f / 255f, 245f / 225f, 10f / 255f);
            yellow = new Color(243f / 255f, 245f / 225f, 24f / 255f);
            orange = new Color(255f / 255f, 179f / 225f, 4f / 255f);
            redOrange = new Color(255f / 255f, 89f / 225f, 4f / 255f);
            red = new Color(255f / 255f, 0f / 225f, 0f / 255f);
            
            //テキストの初期化
            timerText.text = ((int)totalTime).ToString("");
            timerText.color = darkGreen;
        }
        
        
        //制限時間のカウントをするメソッド
        public void Count()
        {
            StartCoroutine(Counting());
        }

        IEnumerator Counting(){
            
            while(totalTime > 0){
                totalTime -= Time.deltaTime;

                //10秒以下になると小数点一位になるようにしています
                if ((int)totalTime >= 10)
                {
                    timerText.text = ((int)totalTime).ToString("");
                }
                else
                {
                    timerText.text = totalTime.ToString("F1");
                }

                ColorChange();
                if (totalTime <= 0) End();

                yield return null;
            }

            yield break;
        }
        //時間に応じてタイムの色を変えるメッソド
        private void ColorChange()
        {
            switch ((int)totalTime)
            {
                case 49:
                    timerText.color = rightGreen;
                    break;
                case 39:
                    timerText.color = yellow;
                    break;
                case 29:
                    timerText.color = orange;
                    break;
                case 19:
                    timerText.color = redOrange;
                    break;
                case 9:
                    timerText.color = red;
                    break;
            }
        }
    }
}