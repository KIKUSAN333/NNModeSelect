using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdNotes : MonoBehaviour
{
    float moveSpeed = 5.0f;
    public float holdPosition;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.F) && transform.position.x < 10 && transform.position.x > -10)
        {
            OnClickButton();
        }
    }

    void OnClickButton()
    {
        holdPosition = transform.position.x;
        // �����ŃG�t�F�N�g���o��(���y�щ��)

        if (holdPosition < 0)
        {
            holdPosition *= -1;
        }
    }
}
