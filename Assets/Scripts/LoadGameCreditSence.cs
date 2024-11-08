using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGameCreditScene : MonoBehaviour
{

    public void OnGameCreditScene()
    {
        SceneManager.LoadScene("GameCreditScene"); //Scene In Buildにシーンを入れる必要あり
    }

}
