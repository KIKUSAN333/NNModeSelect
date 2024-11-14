using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RayCastGenerator : MonoBehaviour
{
    [SerializeField] private KeyCode inputKey;
    [SerializeField] private LayerMask mask;

    public AudioSource audioSource;
    [SerializeField] private AudioClip hitSound;
    private AudioClip holdSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        holdSound  = (AudioClip)Resources.Load("SEs/TapSE_1");
    }

    void Update()
    {
        if (Input.GetKeyDown(inputKey)) ProcessKeyDown_RcGen();
        if (Input.GetKey(inputKey)) ProcessKeyHold_RcGen();
        if (Input.GetKeyUp(inputKey)) ProcessKeyUp_RcGen();
    }

    /// <summary>
    /// キー入力時のメソッド．OverlapとRaycastによってノーツを取得し，そのノーツにキー入力イベントを実行させる．
    /// </summary>
    public void ProcessKeyDown_RcGen()
    {
        audioSource.PlayOneShot(hitSound);
        GameObject hitObject = GetNotesOnLine();
        Notes notes = null;
        if (hitObject != null)
        {
            notes = hitObject.GetComponent<Notes>();
            if (notes != null)
            {
                notes.ProcessHitRaycast(Math.Abs(hitObject.transform.position.x - this.transform.position.x));
                return;
            }
        }

        List<GameObject> hitObjects = ShootRaycastInXDirection();
        if (hitObjects.Count == 0) return;

        foreach (var h in hitObjects)
        {
            notes = h.GetComponent<Notes>();
            if (notes != null)
            {
                notes.ProcessHitRaycast(Math.Abs(h.transform.position.x - this.transform.position.x));
                break;
            }
        }
    }

    /// <summary>
    /// キーホールド時に判定線上をノーツが通ったときの処理．ホールドノーツの途中のノーツ用．
    /// </summary>
    public void ProcessKeyHold_RcGen()
    {
        GameObject hitObject = GetNotesOnLine();
        HoldMidNotes notes = null;
        if (hitObject != null)
        {
            notes = hitObject.GetComponent<HoldMidNotes>();
            if (notes != null)
            {
                notes.ProcessInputEvent();
                audioSource.PlayOneShot(holdSound);
                return;
            }
        }
    }

    /// <summary>
    /// キーを離した時の処理．ホールドノーツの最後のノーツ用．
    /// </summary>
    public void ProcessKeyUp_RcGen()
    {
        GameObject hitObject = GetNotesOnLine();
        HoldEndNotes notes = null;
        if (hitObject != null)
        {
            notes = hitObject.GetComponent<HoldEndNotes>();
            if (notes != null)
            {
                notes.ProcessInputEvent(Math.Abs(hitObject.transform.position.x - this.transform.position.x));
                audioSource.PlayOneShot(hitSound);
                return;
            }
        }

        List<GameObject> hitObjects = ShootRaycastInXDirection();
        if (hitObjects.Count == 0) return;

        foreach (var h in hitObjects)
        {
            notes = h.GetComponent<HoldEndNotes>();
            if (notes != null)
            {
                notes.ProcessInputEvent(Math.Abs(h.transform.position.x - this.transform.position.x));
                audioSource.PlayOneShot(hitSound);
                break;
            }
        }
    }

    private List<GameObject> ShootRaycastInXDirection()
    {
        Vector3 rayOrigin = transform.position;

        RaycastHit2D[] hitRight = Physics2D.RaycastAll(rayOrigin, Vector2.right, 5.0f, mask);

        RaycastHit2D[] hitLeft = Physics2D.RaycastAll(rayOrigin, Vector2.left, 5.0f, mask);

        RaycastHit2D[] hits = hitRight.Concat(hitLeft).ToArray();
        Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));
        return hits.Select(hit => hit.collider.gameObject).ToList();
    }

    private GameObject GetNotesOnLine()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.1f, 0.1f), 0f, mask);
        if (colliders.Length == 0) return null;

        return colliders[0].gameObject;
    }
}
