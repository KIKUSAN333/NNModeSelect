using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scorePoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _comboText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GManager _gManager;

    private void Start()
    {
        _comboText.text = "0";
        _scoreText.text = "0";
    }

    private void Update()
    {
        _comboText.text = GManager.instance.combo.ToString();
        _scoreText.text = GManager.instance.score.ToString();
    }
}
