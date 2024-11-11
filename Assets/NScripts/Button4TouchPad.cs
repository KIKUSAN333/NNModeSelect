using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// タッチパッドに対応させるためのクラス
/// </summary>
public class Button4TouchPad : MonoBehaviour
{
    [SerializeField] private int _laneNum;

    private FlushLight _flushLight = null;
    private RayCastGenerator _raycastGenerator = null;
    private EventTrigger _eventTrigger = null;

    private void Start()
    {
        GetMyComponents();
        SetListeners();
    }

    private void GetMyComponents()
    {
        _flushLight = GetFlushLight(_laneNum);
        _raycastGenerator = GetRaycastGen(_laneNum);
        _eventTrigger = gameObject.AddComponent<EventTrigger>();
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

    private void SetListeners()
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { PointerDown(); });
        _eventTrigger.triggers.Add(entry);
    }

    private void PointerDown()
    {
        _raycastGenerator.ProcessKeyDown_RcGen();
        _flushLight.colorChange();
    }
}
