using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class Tile : MonoBehaviour {

        private Player prevPlayer = null;
        [SerializeField] private Material[] materials;

        private void Awake()
        {
            
        }

        private void OnCollisionEnter(Collision c)
        {
            Player hitedplayer = c.gameObject.GetComponent<Player>();
            if(hitedplayer != null){
                this.gameObject.GetComponent<Renderer>().material = materials[hitedplayer.Number - 1];
                if (hitedplayer == prevPlayer) return;
                ScoreManager.Instance.UpScore(hitedplayer.Number);
                if(prevPlayer != null){
                    ScoreManager.Instance.DownScore(prevPlayer.Number);
                }
                prevPlayer = hitedplayer;
            }
        }
    }
}