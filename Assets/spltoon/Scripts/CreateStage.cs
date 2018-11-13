using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class CreateStage : MonoBehaviour {
        
        [SerializeField] private Tile tile;
        
        public void CreateTiles()
        {
            for (float i = -4.5f; i <= 4.5f; i++)
            {
                for (float f = -4.5f; f <= 4.5f; f++)
                {
                    var t = Instantiate(tile, new Vector3(i, 0, f), Quaternion.identity);
                    t.transform.SetParent(gameObject.transform);
                }
            }
        }
    }
}
