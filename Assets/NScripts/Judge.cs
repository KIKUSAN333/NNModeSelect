using System;
using UnityEngine;
using TMPro;//new!!
public class Judge : MonoBehaviour
{
    ////�ϐ��̐錾
    //[SerializeField] private GameObject[] MessageObj;//�v���C���[�ɔ����`����Q�[���I�u�W�F�N�g
    //[SerializeField] NotesManager notesManager;//�X�N���v�g�unotesManager�v������ϐ�

    //[SerializeField] TextMeshProUGUI comboText;//new!!
    //[SerializeField] TextMeshProUGUI scoreText;//new!!

    //AudioSource audio;
    //[SerializeField] AudioClip hitSound;

    //private float lag = -1f;

    //void Start()
    //{
    //    audio = GetComponent<AudioSource>();

    //}

    //void Update()
    //{
    //    if (GManager.instance.Start)
    //    {
    //        if (Input.GetKeyDown(KeyCode.D))//�Z�L�[�������ꂽ�Ƃ�
    //        {
    //            if (notesManager.LaneNum[0] == 0)//�����ꂽ�{�^���̓��[���̔ԍ��Ƃ����Ă��邩�H
    //            {
    //                Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime) + lag), 0);
    //            }
    //            else
    //            {
    //                if (notesManager.LaneNum[1] == 0)
    //                {
    //                    Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime) + lag), 1);
    //                }
    //            }
    //        }
    //        if (Input.GetKeyDown(KeyCode.F))
    //        {
    //            if (notesManager.LaneNum[0] == 1)
    //            {
    //                Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime) + lag), 0);
    //            }
    //            else
    //            {
    //                if (notesManager.LaneNum[1] == 1)
    //                {
    //                    Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime) + lag), 1);
    //                }
    //            }
    //        }
    //        if (Input.GetKeyDown(KeyCode.J))
    //        {
    //            if (notesManager.LaneNum[0] == 2)
    //            {
    //                Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime) + lag), 0);
    //            }
    //            else
    //            {
    //                if (notesManager.LaneNum[1] == 2)
    //                {
    //                    Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime) + lag), 1);
    //                }
    //            }
    //        }
    //        if (Input.GetKeyDown(KeyCode.K))
    //        {
    //            if (notesManager.LaneNum[0] == 3)
    //            {
    //                Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime) + lag), 0);
    //            }
    //            else
    //            {
    //                if (notesManager.LaneNum[1] == 3)
    //                {
    //                    Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime) + lag), 1);
    //                }
    //            }
    //        }

    //        if (Time.time > notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime - lag)//�{���m�[�c���������ׂ����Ԃ���0.2�b�����Ă����͂��Ȃ������ꍇ
    //        {
    //            message(3);
    //            deleteData(0);
    //            Debug.Log("Miss");
    //            GManager.instance.miss++;
    //            GManager.instance.combo = 0;
    //            //�~�X
    //        }
    //    }
    //}
    //void Judgement(float timeLag, int numOffset)
    //{
    //    audio.PlayOneShot(hitSound);
    //    if (timeLag <= 0.3)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.1�b�ȉ���������
    //    {
    //        Debug.Log("Perfect");
    //        message(0);
    //        GManager.instance.ratioScore += 5;//new!!
    //        GManager.instance.perfect++;
    //        GManager.instance.combo++;
    //        deleteData(numOffset);
    //    }
    //    else
    //    {
    //        if (timeLag <= 0.45 && 0.3 < timeLag)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.15�b�ȉ���������
    //        {
    //            Debug.Log("Great");
    //            message(1);
    //            GManager.instance.ratioScore += 3;//new!!
    //            GManager.instance.great++;
    //            GManager.instance.combo++;
    //            deleteData(numOffset);
    //        }
    //        else
    //        {
    //            if (timeLag <= 0.6 && 0.45 < timeLag)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.2�b�ȉ���������
    //            {
    //                Debug.Log("Bad");
    //                message(2);
    //                GManager.instance.ratioScore += 1;//new!!
    //                GManager.instance.bad++;
    //                GManager.instance.combo = 0;
    //                deleteData(numOffset);
    //            }
    //        }
    //    }
    //}
    //float GetABS(float num)//�����̐�Βl��Ԃ��֐�
    //{
    //    if (num >= 0)
    //    {
    //        return num;
    //    }
    //    else
    //    {
    //        return -num;
    //    }
    //}
    //void deleteData(int numOffset)//���łɂ��������m�[�c���폜����֐�
    //{
    //    notesManager.NotesTime.RemoveAt(numOffset);
    //    notesManager.LaneNum.RemoveAt(numOffset);
    //    notesManager.NoteType.RemoveAt(numOffset);
    //    GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);
    //    //��new!!
    //    comboText.text = GManager.instance.combo.ToString();//new!!
    //    scoreText.text = GManager.instance.score.ToString();//new!!
    //}

    //void message(int judge)//�����\������
    //{
    //    Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0], -1.4f, -10), Quaternion.Euler(0, 0, 0));
    //}
}