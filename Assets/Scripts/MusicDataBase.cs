using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicDataBase", menuName = "CreateMusicDataBase")]

public class MusicDataBase : ScriptableObject
{

    [SerializeField] public MusicData[] MusicData;

}
