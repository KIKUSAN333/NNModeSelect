using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Notes : MonoBehaviour
{
    float NotesSpeed; // �N���X���ɕϐ����`
    public float pushPosition;

    [SerializeField] private float _perfectDist = 0.5f;
    [SerializeField] private float _greatDist = 2.0f;
    [SerializeField] private float _badDist = 4.0f;

    [SerializeField] private GameObject[] MessageObj;
    [SerializeField] private GameObject notesManagerObj;
    private NotesManager notesManager = null;

    bool start;

    void Start()
    {
        NotesSpeed = GManager.instance.notesSpeed;
        notesManager = notesManagerObj.GetComponent<NotesManager>(); ;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }

        if (start)
        {
            transform.Translate(Vector3.left * NotesSpeed * Time.deltaTime);
        }

        if (isOutOfDisplay())
        {
            GManager.instance.combo = 0;
            GManager.instance.miss++;
            Message(3);
            DeleteThis();
        }
    }

    /// <summary>
    /// キー入力時のイベント
    /// </summary>
    /// <param name="distFromBaseline"></param>
    public void ProcessKeyDown (float distFromBaseline) {
        judge(distFromBaseline);
    }

    private bool isOutOfDisplay()
    {
        return transform.position.x < -9;
    }

    private void judge(float distFromBaseline)
    {
        if (distFromBaseline <= _perfectDist) {
            ProcessPerfect();
            return;
        }
        if (distFromBaseline <= _greatDist)
        {
            ProcessGreat();
            return;
        }
        if (distFromBaseline <= _badDist)
        {
            ProcessBad();
            return;
        }
    }

    private void ProcessPerfect()
    {
        GManager.instance.combo++;
        GManager.instance.score += 5;
        GManager.instance.perfect++;
        Message(0);
        DeleteThis();
    }

    private void ProcessGreat()
    {
        GManager.instance.combo++;
        GManager.instance.score += 3;
        GManager.instance.great++;
        Message(1);
        DeleteThis();
    }

    private void ProcessBad()
    {
        GManager.instance.combo = 0;
        GManager.instance.score += 1;
        GManager.instance.bad++;
        Message(2);
        DeleteThis();
    }

    private void Message(int judge)
    {
        Instantiate(MessageObj[judge], new Vector3(-4, transform.position.y, 0), Quaternion.Euler(0, 0, 0));
    }

    private void DeleteThis()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }
}