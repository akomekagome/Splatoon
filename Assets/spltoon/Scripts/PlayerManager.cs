using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Splatoon;

namespace Splatoon{
    
    public class PlayerManager : BestPracticeSingleton<PlayerManager>
    {
        private List<Player> playersList;
        private Move[] playerMoves;
        private Attack[] playerAttacks;
        private bool[] canMoves;

        private void Awake()
        {
            playersList = new List<Player>();
            
            playerMoves = new Move[GameManager.Instance.PlayabelePersons];
            
            playerAttacks = new Attack[GameManager.Instance.PlayabelePersons];

            canMoves = new bool[GameManager.Instance.PlayabelePersons];

            var playersArray = new Player[Constants.GameSetting.MAX_PERSONS];


            foreach (Transform child in transform)
            {

                var player = child.GetComponent<Player>();

                if (player == null)
                {
                    Debug.Log(child.name + "にPlayerがアタッチされていません");
                    return;
                }

                playersArray[player.Number - 1] = player;
            }

            //プレイヤーの操作人数の変化に対応するために入れています
            playersList.AddRange(playersArray);

            //プレイヤーの操作人数の変化に対応するために入れています。
            for (int i = GameManager.Instance.PlayabelePersons; i < Constants.GameSetting.MAX_PERSONS; i++)
            {
                playersList[GameManager.Instance.PlayabelePersons].gameObject.SetActive(false);
                playersList.RemoveAt(GameManager.Instance.PlayabelePersons);
            }

            for (int i = 0; i < playersList.Count(); i++)
            {
                var move = playersList[i].GetComponent<Move>();
                if (move == null) { Debug.Log("null"); return; }
                playerMoves[i] = move;
                move.Number = playersList[i].Number;
            }

            for (int i = 0; i < playersList.Count(); i++)
            {
                var attack = playersList[i].GetComponent<Attack>();
                if (attack == null) { Debug.Log("null"); return; }
                playerAttacks[i] = attack;
                attack.Number = playersList[i].Number;
            }

            for (int i = 0; i < playersList.Count(); i++)
            {
                var damage = playersList[i].GetComponent<Damage>();
                if (damage == null) { Debug.Log("null"); return; }
                damage.Number = playersList[i].Number;
                damage.setCanMove = (canMove, number) => { canMoves[number - 1] = canMove; playerMoves[number - 1].CanMove = canMove;};
            }
        }

        public void MoveStart()
        {
            for (int i = 0; i < canMoves.Count(); i++)
            {
                canMoves[i] = true;
            }

            foreach (var move in playerMoves)
            {
                move.CanMove = true;
            }
            if (!GameManager.Instance.JoyconMode) { canMoves[1] = false; playerMoves[1].CanMove = false; }
        }

        public void MoveEnd()
        {
            for (int i = 0; i < canMoves.Count(); i++)
            {
                canMoves[i] = false;
            }

            foreach (var move in playerMoves)
            {
                move.CanMove = false;
            }
        }

        private void Update()
        {
            for (int i = 0; i < canMoves.Count(); i++){
                if(canMoves[i]){
                    playerMoves[i].PlayerUqdate();
                    playerAttacks[i].PlayerUpdate();
                }
            }
        }


        public Player GetPlayer(int number)
        {
            return playersList[number - 1];
        }
    }
}