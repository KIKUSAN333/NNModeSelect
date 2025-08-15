using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip Music;
    bool played;

    [SerializeField] private string songName;

    void Start()
    {
        GManager.instance.Start = false;
        audioSource = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);  //変数Musicにオーディオファイルを入れる
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !played) StartMusic();
        if (Input.GetMouseButtonDown(0) && !played) StartMusic();

        if (isFinished()) LoadResultPage();
    }

    private void StartMusic()
    {
        GManager.instance.Start = true;
        GManager.instance.StartTime = Time.time;
        played = true;
        audioSource.PlayOneShot(Music);
    }

    private bool isFinished()
    {
        return !audioSource.isPlaying && played;
    }

    private void LoadResultPage()
    {
        SceneManager.LoadScene("Result");
    }
}
