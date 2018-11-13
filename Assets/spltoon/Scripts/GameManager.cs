using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class GameManager : Singleton<GameManager> {

        //プレイ可能人数ジョイコンを接続する場合はこの値をヒエラルキーから変更して下さい
        [SerializeField] private int playablePersons = 4;
        private Timer timer;
        private Bgm bgm;

        public int PlayabelePersons { get { return playablePersons; } }

        void Start () {
            var cs = FindObjectOfType<CreateStage>();
            cs.CreateTiles();

            var cd = FindObjectOfType<CountDown>();
            cd.CountStart();

            timer = FindObjectOfType<Timer>();

            timer.End += () => cd.EndProcess();

            bgm = FindObjectOfType<Bgm>();
        }

        public void End(){
            PlayerManager.Instance.MoveEnd();
            ScoreManager.Instance.AddRank();
            FindObjectOfType<RankContorller>().GetRank();
            bgm.EndBgm();

            enabled = false;
            return;
        }

        public void GameStart(){
            timer.Count();
            PlayerManager.Instance.MoveStart();
            bgm.PlayBgm();
        }
    }
}