using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAssistLine : MonoBehaviour
{
    float NotesSpeed; // �N���X���ɕϐ����`
    bool start;

    void Start()
    {
        NotesSpeed = GManager.instance.notesSpeed;
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

    }
}
