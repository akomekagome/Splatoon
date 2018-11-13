using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;


namespace Splatoon{

    public class Player : MonoBehaviour
    {
        [SerializeField] private int number;
        [SerializeField] private Color color;


        public Color Color{ get { return color; }}
        public int Number{ get { return number; }}
    }
}
