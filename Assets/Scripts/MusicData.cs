using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MusicData", menuName = "CreateMusicData")]

public class MusicData : ScriptableObject
{ 

    [SerializeField] public string MusicName;
    [SerializeField] public int MusicLevel;
    [SerializeField] public Sprite MusicImage;
    [SerializeField] public AudioClip Music;

}
