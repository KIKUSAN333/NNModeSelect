using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicSelect : MonoBehaviour
{
    //�f�[�^�x�[�X�Ɋy�Ȃ��ǉ�����Ă��邩�m�F����//


    [SerializeField] MusicDataBase DataBase;
    [SerializeField] Text MusicNameText;
    [SerializeField] Text MusicLevelText;
    [SerializeField] Image MusicImage;

    AudioSource audio;

    int SelectMusicNumber;//�I���Ȃ̕ϐ�

    private void Start()//������
    {
        SelectMusicNumber = 0;
        audio = GetComponent<AudioSource>();
        MusicUpdata();
    }

    public void RightButtonPush()
    {
        Debug.Log("RightButtonPush");
 
        SelectMusicNumber = (SelectMusicNumber + 1) % (DataBase.MusicData.Length);
        MusicUpdata();
        
    }

    public void LeftButtonPush()
    {
        Debug.Log("LeftButtonPush");

        SelectMusicNumber = (SelectMusicNumber - 1 + DataBase.MusicData.Length) % (DataBase.MusicData.Length);
        MusicUpdata();
        
    }


    //���Q�[�{�̕����̃V�[���̖��O���y�Ȗ��ɂ���K�v����
    public void ChoiceMusic()
    {
        string ChoiceSceneName = DataBase.MusicData[SelectMusicNumber].MusicName;   //�f�[�^�x�[�X����y�Ȗ��������Ă���
        SceneManager.LoadScene(ChoiceSceneName);    //�y�Ȗ��Ɠ������O�̃V�[�������[�h����
    }



    private void MusicUpdata()
    {

        audio.clip = DataBase.MusicData[SelectMusicNumber].Music;//�f�[�^�x�[�X����y�Ȃ������Ă���
        audio.Play();

        //�f�[�^�x�[�X����y�Ȗ�,�y�ȃ��x��,�y�ȉ摜�������Ă���
        MusicNameText.text = DataBase.MusicData[SelectMusicNumber].MusicName;
        MusicLevelText.text = "Lv." + DataBase.MusicData[SelectMusicNumber].MusicLevel;
        MusicImage.sprite = DataBase.MusicData[SelectMusicNumber].MusicImage;

    }



}
