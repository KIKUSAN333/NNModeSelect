using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadStartScene : MonoBehaviour
{

    public void OnStartScene()
    {
        SceneManager.LoadScene("StartScene"); //Scene In Buildにシーンを入れる必要あり
    }

}
