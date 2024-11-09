using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastGenerator : MonoBehaviour
{
    [SerializeField] private KeyCode inputKey;
    [SerializeField] private float raycastDistance = 9.0f;

    public AudioSource audio;
    [SerializeField] private AudioClip hitSound;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            audio.PlayOneShot(hitSound);
            GameObject hitObject = GetNotesOnLine();
            Notes notes = null;
            if (hitObject != null)
            {
                notes = hitObject.GetComponent<Notes>();
                notes.ProcessKeyDown(Math.Abs(hitObject.transform.position.x - this.transform.position.x));
                return;
            }

            hitObject = ShootRaycastInXDirection();
            if (hitObject == null) return;
            
            notes = hitObject.GetComponent<Notes>();
            notes.ProcessKeyDown(Math.Abs(hitObject.transform.position.x - this.transform.position.x));
        }
    }

    private GameObject ShootRaycastInXDirection()
    {
        Vector3 rayOrigin = transform.position;

        RaycastHit hitRight;
        Vector3 rayDirection = transform.right;
        bool hitRightSuccess = Physics.Raycast(rayOrigin, rayDirection, out hitRight, raycastDistance);

        RaycastHit hitLeft;
        rayDirection *= -1;
        bool hitLeftSuccess = Physics.Raycast(rayOrigin, rayDirection, out hitLeft, raycastDistance);

        if (!hitRightSuccess && !hitLeftSuccess) return null;
        if (hitRightSuccess && !hitLeftSuccess) return hitRight.transform.gameObject;
        if (!hitRightSuccess && hitLeftSuccess) return hitLeft.transform.gameObject;

        RaycastHit hit = Mathf.Min(hitLeft.distance, hitRight.distance)==hitLeft.distance ? hitLeft : hitRight;

        return hit.transform.gameObject;
    }

    private GameObject GetNotesOnLine()
    {
        Collider[] collider = Physics.OverlapBox(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
        if (collider.Length == 0) return null;

        return collider[0].gameObject;
    }
}
