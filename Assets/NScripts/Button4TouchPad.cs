using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// タッチパッドに対応させるためのクラス
/// </summary>
public class Button4TouchPad : MonoBehaviour
{
    [SerializeField] private int _laneNum;

    private FlushLight _flushLight = null;
    private RayCastGenerator _raycastGenerator = null;
    private EventTrigger _eventTrigger = null;
    private bool _isHolding = false;

    private void Start()
    {
        GetMyComponents();
        SetListeners();
    }

    private void Update()
    {
        if (_isHolding) OnPointerHold();
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
        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerDown
        };
        pointerDownEntry.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        _eventTrigger.triggers.Add(pointerDownEntry);

        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerUp
        };
        pointerUpEntry.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
        _eventTrigger.triggers.Add(pointerUpEntry);
    }

    private void OnPointerDown(PointerEventData data)
    {
        _raycastGenerator.ProcessKeyDown_RcGen();
        _flushLight.colorChange();
        _isHolding = true;
    }

    private void OnPointerUp(PointerEventData data)
    {
        _raycastGenerator.ProcessKeyUp_RcGen();
        _isHolding = false;
    }

    private void OnPointerHold()
    {
        _raycastGenerator.ProcessKeyHold_RcGen();
    }
}
