using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek nesne

    public float smoothSpeed = 0.125f; // Kamera yumu�akl�k h�z�
    public Vector3 offset; // Kamera ile hedef aras�ndaki mesafe

    public Vector2 minPosition; // Minimum s�n�rlar
    public Vector2 maxPosition; // Maksimum s�n�rlar

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(
            Mathf.Clamp(smoothedPosition.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(smoothedPosition.y, minPosition.y, maxPosition.y),
            smoothedPosition.z
        );

        transform.LookAt(target);
    }
}
