using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Splatoon;

namespace Splatoon{
    
    public class CountDown : MonoBehaviour
    {

        private Text countText;

        // Use this for initialization
        public void Awake()
        {
            countText = GetComponent<Text>();
            countText.text = "";

        }

        public void CountStart()
        {

            StartCoroutine(Countdown());
        }

        IEnumerator Countdown()
        {
            yield return new WaitForSeconds(1.0f);
            countText.text = "3";
            GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(1.0f);
            countText.text = "2";

            yield return new WaitForSeconds(1.0f);
            countText.text = "1";

            yield return new WaitForSeconds(1.0f);
            GameManager.Instance.GameStart();
            countText.text = "GO!";

            yield return new WaitForSeconds(0.5f);
            countText.text = "";
            countText.gameObject.SetActive(false);
        }

        public void EndProcess()
        {
            gameObject.SetActive(true);
            StartCoroutine(TimeUp());
        }

        IEnumerator TimeUp()
        {
            countText.text = "TIME UP!";
            yield return new WaitForSeconds(1.0f);
            gameObject.SetActive(false);
            GameManager.Instance.End();
        }

    }
}