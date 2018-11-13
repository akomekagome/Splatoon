using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class RankContorller : MonoBehaviour {
        
        private Rank[] rankclass;
        // Use this for initialization

        void Start()
        {
            rankclass = new Rank[GameManager.Instance.PlayabelePersons];

            foreach (Transform child in transform)
            {
                var rank = child.GetComponent<Rank>();

                if (rank == null)
                {
                    Debug.Log(child.name + "にRankがアタッチされていません");
                    return;
                }

                rank.gameObject.SetActive(false);

                if (rank.Number > GameManager.Instance.PlayabelePersons) continue;
                rankclass[rank.Number - 1] = rank;
            }
        }

        public void GetRank()
        {
            StartCoroutine(SendRank());
        }

        IEnumerator SendRank()
        {
            for (int rank = GameManager.Instance.PlayabelePersons; rank > 0; rank--)
            {
                if (ScoreManager.Instance.SortArray(rank) == false) continue;
                for (int f = 1; f <= GameManager.Instance.PlayabelePersons; f++)
                {
                    if (ScoreManager.Instance.GetRank(f) == rank)
                    {
                        rankclass[f - 1].gameObject.SetActive(true);
                        rankclass[f - 1].RankWrite(rank);
                    }
                }
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}