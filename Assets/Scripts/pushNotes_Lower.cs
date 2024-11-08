using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushNotes_Lower : MonoBehaviour
{
    float moveSpeed = 5.0f; // �N���X���ɕϐ����`
    public float pushPosition;

    private RectTransform rectTransform;

    public static int pushLowerCount_Great = 0;
    public static int pushLowerCount_Good = 0;
    public static int pushLowerCount_Miss = 0;

    [SerializeField]
    private SoundManager soundManager; //�T�E���h�}�l�[�W���[

    void Start()
    {
        // RectTransform �R���|�[�l���g���擾
        rectTransform = GetComponent<RectTransform>();//�A�X�y�N�g����Œ肳���Ă��邽��RectTransform���g��

        Debug.Log("Anchored Position: " + rectTransform.anchoredPosition.x);
        Debug.Log("World Position: " + rectTransform.position);

    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);//�m�[�c�̈ړ�

        if (Input.GetKey(KeyCode.K) &&  -875 <= rectTransform.anchoredPosition.x && rectTransform.anchoredPosition.x <= -845)//����
        {

            OnClickButton_Great();
        }
        else if (Input.GetKey(KeyCode.K) && -890 <= rectTransform.anchoredPosition.x && rectTransform.anchoredPosition.x <= -830)
        {

            OnClickButton_Good();
        }
        else if (Input.GetKey(KeyCode.K) && rectTransform.anchoredPosition.x <= -820)//�����~�X
        {
            Miss();
            Debug.Log(rectTransform.name +"   X Position: " + this.rectTransform.anchoredPosition.x + "   Judgement_FastMiss");
        }
        else if (rectTransform.anchoredPosition.x <= - 900)//�x���~�X
        {
            Miss();
            Debug.Log(rectTransform.name + "   X Position: " + this.rectTransform.anchoredPosition.x + "   Judgement_LateMiss");
        }


    }

    void OnClickButton_Great()
    {

        Debug.Log(rectTransform.name + "   X Position: " + this.rectTransform.anchoredPosition.x + "   Judgement_Great");

        pushLowerCount_Great++;

        pushPosition = transform.position.x;
        // �����ŃG�t�F�N�g���o��(���y�щ��)
        soundManager.Play("GreatSE");

        Destroy(this.gameObject);//�m�[�c�폜

        if (pushPosition < 0)
        {
            pushPosition *= -1;
        }

    }

    void OnClickButton_Good()
    {

        Debug.Log(rectTransform.name + "   X Position: " + this.rectTransform.anchoredPosition.x + "   Judgement_Good");

        pushLowerCount_Good++;

        pushPosition = transform.position.x;
        // �����ŃG�t�F�N�g���o��(���y�щ��)
        soundManager.Play("GoodSE");

        Destroy(this.gameObject);//�m�[�c�폜

        if (pushPosition < 0)
        {
            pushPosition *= -1;
        }

    }

    void Miss()
    {



        pushLowerCount_Miss++;

        pushPosition = transform.position.x;
        // �����ŃG�t�F�N�g���o��(���y�щ��)
        soundManager.Play("MissSE");

        Destroy(this.gameObject);//�m�[�c�폜

        if (pushPosition < 0)
        {
            pushPosition *= -1;
        }
    }

}