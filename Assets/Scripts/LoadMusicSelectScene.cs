using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMusicSelectScene : MonoBehaviour
{

    public void OnMusicSelectScene()
    {
        SceneManager.LoadScene("MusicSelectScene"); //Scene In Buildにシーンを入れる必要あり
    }

}
