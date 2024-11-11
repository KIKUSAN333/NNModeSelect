using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タッチパッドに対応させるためのクラス
/// </summary>
public class Button4TouchPad : MonoBehaviour
{
    [SerializeField] private int _laneNum;

    private FlushLight _flushLight = null;
    private RayCastGenerator _raycastGenerator = null;

    private Button button;

    private void Start()
    {
        GetMyComponents();
        SetListeners2Button();
    }

    private void GetMyComponents()
    {
        button = GetComponent<Button>();
        _flushLight = GetFlushLight(_laneNum);
        _raycastGenerator = GetRaycastGen(_laneNum);
    }

    private FlushLight GetFlushLight(int num)
    {
        GameObject go = num == 1 ? GameObject.Find("Light") : GameObject.Find("Light (" + num + ")");
        return go.GetComponent<FlushLight>();
    }

    private RayCastGenerator GetRaycastGen(int num)
    {
        GameObject go = GameObject.Find("RayCastGenerator_Line" + num);
        return go.GetComponent<RayCastGenerator>();
    }

    private void SetListeners2Button()
    {
        button.onClick.AddListener(() => _raycastGenerator.ProcessKeyDown_RcGen());
        button.onClick.AddListener(() => _flushLight.colorChange());
    }
}
