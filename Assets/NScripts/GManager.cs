using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GManager>();

                if (_instance == null)
                {
                    GameObject go = new GameObject("GManager");
                    _instance = go.AddComponent<GManager>();
                }
            }
            return _instance;
        }
    }

    private static GManager _instance = null;

    public float maxScore;
    public float ratioScore;

    public int songID;  //曲のID
    public float notesSpeed;  //ノーツスピード

    public bool Start;
    public float StartTime;

    public int combo;  //現在のコンボ数を記録
    public int score;  //現在のスコアを記録

    //以下、それぞれの判定を記録
    public int perfect;
    public int great;
    public int bad;
    public int miss;

    //このスクリプトがシーンに一つしかないようにしている
    public void Awake()
    {
        if (_instance == null)
        {
            Debug.Log("GManager_test");
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
        else
        {
        
            Debug.Log("GManager_Destroy");
            Destroy(this.gameObject);
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    public static GManager _instance
    {
            get
            {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GManager>();
            }

                if (_instance == null)
                {
                    GameObject go = new GameObject("GManager");
                    _instance = go.AddComponent<GManager>();
                }
            return _instance;
        }

    }

    public float maxScore;//new!!
    public float ratioScore;//new!!

    public int songID;
    public float notesSpeed;

    public bool Start;
    public float StartTime;

    public int combo;
    public int score;

    public int perfect;
    public int great;
    public int bad;
    public int miss;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }
}*/