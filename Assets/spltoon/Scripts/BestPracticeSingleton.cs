using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Splatoon;
// 以下のURL参考
// http://blog.livedoor.jp/akinow/archives/52511344.html

public class BestPracticeSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    //Returns the instance of this singleton. 
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                }
            }
            return instance;
        }
    }
}