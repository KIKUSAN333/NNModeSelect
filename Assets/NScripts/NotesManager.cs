using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public float offset;
    public Note[] notes;

}

[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
    public List<Note> notes = new List<Note>();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="_type">ノーツのタイプ(ノーマルかロングか)</param>
    /// <param name="_num">ノーツの楽曲の拍数に基づく位置</param>
    /// <param name="_block">ノーツのレーン番号</param>
    /// <param name="_LPB">拍あたりのノーツ数</param>
    /// <param name="_notes">ロングノーツの場合の終了位置(typeが1の場合，nullになる)</param>
    public Note(int _type, int _num, int _block, int _LPB, List<Note> _notes)
    {
        type = _type;
        num = _num;
        block = _block;
        LPB = _LPB;
        notes = null;
    }
}

public class NotesManager : MonoBehaviour
{
    public int noteNum;
    [SerializeField] private string songName;

    private List<int> LaneNum = new List<int>();
    private List<int> NoteType = new List<int>();
    private List<float> NotesTime = new List<float>();
    private List<GameObject> NotesObj = new List<GameObject>();  //ノーツのオブジェクト自体を入れる

    private float NotesSpeed;
    [SerializeField] GameObject noteObj;
    [SerializeField] GameObject holdStartNoteObj;
    [SerializeField] GameObject holdEndNoteObj;
    [SerializeField] GameObject holdMidNoteObj;
    [SerializeField] GameObject holdAssistLine;

    private Data inputJson;
    private List<Note> normalNotes = new List<Note>();
    private List<(Note, int)> longNotes = new List<(Note, int)>();

    void OnEnable()
    {
        GManager.instance.InitVals();
        Debug.Log(GManager.instance);
        NotesSpeed = GManager.instance.notesSpeed;
        noteNum = 0;
        Load(songName);
    }

    private void Load(string SongName)
    {
        
        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        inputJson = JsonUtility.FromJson<Data>(inputString);

        noteNum = inputJson.notes.Length;
        GManager.instance.maxScore = noteNum * 5;//new!!

        Debug.Log(inputJson.name.ToString());
        DivideByNoteType();
        GenerateNormalNotes();
        GenerateLongNotes();
    }

    private void DivideByNoteType()
    {
        foreach ((Note note, int index) in inputJson.notes.Select((v, i) => (v, i)))
        {
            if (note.type == 2)
            {
                longNotes.Add((note, index));
                continue;
            }

            normalNotes.Add(note);
        }
    }

    private void GenerateNormalNotes()
    {
        foreach (Note note in normalNotes)
        {
            float kankaku = 60 / (inputJson.BPM * (float)note.LPB);
            float beatSec = kankaku * (float)note.LPB;
            float time = (beatSec * note.num / (float)note.LPB) + inputJson.offset + 0.01f;
            LaneNum.Add(note.block);
            NoteType.Add(note.type);
            float x = time * NotesSpeed;
            NotesObj.Add(Instantiate(noteObj, new Vector3(x - 3, (note.block) * 1.73f - 2.65f, 0), Quaternion.identity));
        }
    }

    private void GenerateLongNotes()
    {
        foreach ((Note note, int index) in longNotes)
        {
            float kankaku = 60 / (inputJson.BPM * (float)note.LPB);
            float beatSec = kankaku * (float)note.LPB;
            float time = (beatSec * note.num / (float)note.LPB) + inputJson.offset + 0.01f;
            LaneNum.Add(note.block);
            NoteType.Add(note.type);
            float xLeft = time * NotesSpeed;
            NotesObj.Add(Instantiate(holdStartNoteObj, new Vector3(xLeft - 3, (note.block) * 1.73f - 2.65f, 0), Quaternion.identity));

            if (note.notes.Count > 0)
            {
                kankaku = 60 / (inputJson.BPM * (float)note.notes[0].LPB);
                beatSec = kankaku * (float)note.notes[0].LPB;
                time = (beatSec * note.notes[0].num / (float)note.notes[0].LPB) + inputJson.offset + 0.01f;
                float xRight = time * NotesSpeed;
                Instantiate(holdEndNoteObj, new Vector3(xRight - 3, (note.block) * 1.73f - 2.65f, 0), Quaternion.identity);

                float xMidDuration = (xRight - xLeft) / 4;

                for (int i = 1; i <= 3; ++i)
                {
                    Instantiate(holdMidNoteObj, new Vector3(xLeft + (i * xMidDuration) - 3, (note.block) * 1.73f - 2.65f, 0), Quaternion.identity);
                }

                GameObject assistLine = Instantiate(holdAssistLine, new Vector3(xLeft - 3, (note.block) * 1.73f - 2.65f, 0), Quaternion.identity);

                Transform transform = assistLine.GetComponent<Transform>();

                float originalPositionX = transform.position.x;
                float newScaleX = xRight - xLeft;

                transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector3(originalPositionX + (newScaleX / 2), transform.position.y, transform.position.z);
            }
        }
    }
}
