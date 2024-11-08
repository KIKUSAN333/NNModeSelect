using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCreditManager : MonoBehaviour
{
    float moveSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);//ƒm[ƒc‚ÌˆÚ“®
    }
}
