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

    public int songID;  //�Ȃ�ID
    public float notesSpeed;  //�m�[�c�X�s�[�h

    public bool Start;
    public float StartTime;

    public int combo;  //���݂̃R���{�����L�^
    public int score;  //���݂̃X�R�A���L�^

    //�ȉ��A���ꂼ��̔�����L�^
    public int perfect;
    public int great;
    public int bad;
    public int miss;

    //���̃X�N���v�g���V�[���Ɉ�����Ȃ��悤�ɂ��Ă���
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