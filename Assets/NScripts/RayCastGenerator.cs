using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastGenerator : MonoBehaviour
{
    [SerializeField] private KeyCode inputKey;
    [SerializeField] private LayerMask mask;

    public AudioSource audioSource;
    [SerializeField] private AudioClip hitSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(inputKey)) ProcessKeyDown_RcGen();
        if (Input.GetKey(inputKey)) ProcessKeyHold_RcGen();
        if (Input.GetKeyUp(inputKey)) ProcessKeyUp_RcGen();
    }

    /// <summary>
    /// �L�[���͎��̃��\�b�h�DOverlap��Raycast�ɂ���ăm�[�c���擾���C���̃m�[�c�ɃL�[���̓C�x���g�����s������D
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

        hitObject = ShootRaycastInXDirection();
        if (hitObject == null) return;

        notes = hitObject.GetComponent<Notes>();
        if (notes == null) return;

        notes.ProcessHitRaycast(Math.Abs(hitObject.transform.position.x - this.transform.position.x));
    }

    /// <summary>
    /// �L�[�z�[���h���ɔ��������m�[�c���ʂ����Ƃ��̏����D�z�[���h�m�[�c�̓r���̃m�[�c�p�D
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
                audioSource.PlayOneShot(hitSound);
                return;
            }
        }
    }

    /// <summary>
    /// �L�[�𗣂������̏����D�z�[���h�m�[�c�̍Ō�̃m�[�c�p�D
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

        hitObject = ShootRaycastInXDirection();
        if (hitObject == null) return;

        notes = hitObject.GetComponent<HoldEndNotes>();
        if (notes == null) return;

        notes.ProcessInputEvent(Math.Abs(hitObject.transform.position.x - this.transform.position.x));
        audioSource.PlayOneShot(hitSound);
    }

    private GameObject ShootRaycastInXDirection()
    {
        Vector3 rayOrigin = transform.position;

        RaycastHit2D hitRight = Physics2D.Raycast(rayOrigin, Vector2.right, Mathf.Infinity, mask);

        RaycastHit2D hitLeft = Physics2D.Raycast(rayOrigin, Vector2.left, Mathf.Infinity, mask);

        if (hitRight.collider == null && hitLeft.collider == null) return null;
        if (hitRight.collider != null && hitLeft.collider == null) return hitRight.collider.gameObject;
        if (hitRight.collider == null && hitLeft.collider != null) return hitLeft.collider.gameObject;

        RaycastHit2D hit = Mathf.Min(hitLeft.distance, hitRight.distance) == hitLeft.distance ? hitLeft : hitRight;

        return hit.collider.gameObject;
    }

    private GameObject GetNotesOnLine()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.1f, 0.1f), 0f, mask);
        if (colliders.Length == 0) return null;

        return colliders[0].gameObject;
    }
}
