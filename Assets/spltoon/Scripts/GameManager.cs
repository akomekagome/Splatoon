using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class GameManager : Singleton<GameManager> {

        //プレイ可能人数ジョイコンを接続する場合はこの値をヒエラルキーから変更して下さい
        private int playablePersons;
        private Timer timer;
        private Bgm bgm;
        [SerializeField] private bool joyconMode = false;

        public int PlayabelePersons { get { return playablePersons; } }
        public bool JoyconMode { get { return joyconMode; }}

        private void Awake()
        {
            if (joyconMode){
                JoyconController.Instance.Init();
                playablePersons = JoyconController.Instance.GetJoyconLength();
            } 
            else{
                JoyconController.Instance.gameObject.SetActive(false);
                playablePersons = 2;
                Debug.Log("joyconを使いたい場合はヒエラルキーのGameManagerのjoyconModeにチェックを入れてください。");
            }
        }

        private void Start()
        {
            var cs = FindObjectOfType<CreateStage>();
            cs.CreateTiles();

            var cd = FindObjectOfType<CountDown>();

            timer = FindObjectOfType<Timer>();
            
            timer.End += () => cd.EndProcess();
            
            bgm = FindObjectOfType<Bgm>();

            cd.CountStart();
        }

        public void End(){
            PlayerManager.Instance.MoveEnd();
            ScoreManager.Instance.AddRank();
            FindObjectOfType<RankContorller>().GetRank();
            bgm.EndBgm();
        }

        public void GameStart(){
            timer.Count();
            PlayerManager.Instance.MoveStart();
            bgm.PlayBgm();
        }
    }
}