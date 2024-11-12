using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldMidNotes : MonoBehaviour
{
    float NotesSpeed; // �N���X���ɕϐ����`
    public float pushPosition;

    [SerializeField] private float _perfectDist = 0.5f;

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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
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
    public void ProcessInputEvent () {
        ProcessPerfect();
    }

    private bool isOutOfDisplay()
    {
        return transform.position.x < -9;
    }

    private void ProcessPerfect()
    {
        GManager.instance.combo++;
        GManager.instance.score += 1;
        GManager.instance.perfect++;
        Message(0);
        DeleteThis();
    }

    private void Message(int judge)
    {
        Instantiate(MessageObj[judge], new Vector3(-4, transform.position.y, 0), Quaternion.Euler(0, 0, 0));
    }

    private void DeleteThis()
    {
        Destroy(gameObject);
    }
}
