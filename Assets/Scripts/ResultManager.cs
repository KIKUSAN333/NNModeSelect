using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace G_2.Music2024.nnna
{
    public class ResultManager : MonoBehaviour
    {
        public Text _scoreTextInResult;
        public Text _PGBMTextInResult;

        void Start()
        {
            PaintScore();
        }

        private void PaintScore()
        {
            _scoreTextInResult.text = "SCORE: " + GManager.instance.score.ToString();
            _PGBMTextInResult.text = "PERFECT: " + GManager.instance.perfect.ToString() + "\n";
            _PGBMTextInResult.text += "GREAT: " + GManager.instance.great.ToString() + "\n";
            _PGBMTextInResult.text += "BAD: " + GManager.instance.bad.ToString() + "\n";
            _PGBMTextInResult.text += "MISS: " + GManager.instance.miss.ToString();
        }

    }
}
