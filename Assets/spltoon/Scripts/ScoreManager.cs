using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    public class ScoreManager : Singleton<ScoreManager> {

        private List<Score> scoresList;
        private int[] scores;
        private int[] ranks;

        // Use this for initialization
        void Start () {
            scores = new int[GameManager.Instance.PlayabelePersons];
            scoresList = new List<Score>();
            ranks = new int[scores.Length];

            for (int i = 0; i < scores.Length; i++) { scores[i] = 0; ranks[i] = 1; }
            //初期化
            var scoresArray = new Score[Constants.GameSetting.MAX_PERSONS];
            
            foreach (Transform child in transform)
            {
                
                var score = child.GetComponent<Score>();
                
                if (score == null)
                {
                    Debug.Log(child.name + "にScoreがアタッチされていません");
                    return;
                }
                
                scoresArray[score.Number - 1] = score;
            }
            
            //プレイヤーの操作人数の変化に対応するために入れています
            scoresList.AddRange(scoresArray);

            //プレイヤーの操作人数の変化に対応するために入れています
            for (int i = GameManager.Instance.PlayabelePersons; i < Constants.GameSetting.MAX_PERSONS; i++)
            {
                scoresList[GameManager.Instance.PlayabelePersons].gameObject.SetActive(false);
                scoresList.RemoveAt(GameManager.Instance.PlayabelePersons);
            }

            //foreach(var score in scoresList){
            //    score.ScoreTextColorChange(PlayerManager.Instance.GetPlayer(score.Number).Color);
            //}
        }

        public void UpScore(int number){
            scores[number - 1]++;
            SendScore(number);
        }

        public void DownScore(int number){
            scores[number - 1]--;
            SendScore(number);
        }

        private void SendScore(int number){
            scoresList[number - 1].SetScoreUI(scores[number - 1]);
        }

        public void AddRank()
        {
            int i, j;
            for (i = 0; i < ranks.Length - 1; i++)
            {
                for (j = i + 1; j < ranks.Length; j++)
                {
                    if (scores[i] < scores[j]) ranks[i]++;
                    else if (scores[i] > scores[j]) ranks[j]++;
                }
            }

        }
        public bool SortArray(int x)
        {
            for (int i = 0; i < scores.Length; i++) if (ranks[i] == x) return true;
            return false;
        }

        public int GetRank(int number)
        {
            return ranks[number - 1];
        }
    }
    
}
