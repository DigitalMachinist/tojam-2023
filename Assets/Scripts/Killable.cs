using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Killable : MonoBehaviour
{
    public event Action Killed;
    
    public Transform Movable;
    public CanvasGroup FadeCanvas;
    public float PreDeathSeconds = 1.5f;
    public float PostDeathSeconds = 0.5f;

    public bool IsRespawning { get; private set; }
    public Transform OriginalParent { get; private set; }
    public Vector3 OriginalPosition { get; private set; }
    public Quaternion OriginalRotation { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public IEnumerator Coroutine { get; private set; }
    
    void Start()
    {
        IsRespawning = false;
        OriginalParent = Movable.parent;
        OriginalPosition = Movable.position;
        OriginalRotation = Movable.rotation;
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Kill()
    {
        if (Coroutine != null)
        {
            StopCoroutine(Coroutine);
        }

        Coroutine = CoKill();
        StartCoroutine(Coroutine);
    }

    IEnumerator CoKill()
    {
        IsRespawning = true;
        
        var elapsedTime = 0f;
        while (elapsedTime < PreDeathSeconds)
        {
            if (FadeCanvas)
            {
                FadeCanvas.alpha = elapsedTime / PreDeathSeconds;
            }
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        if (FadeCanvas)
        {
            FadeCanvas.alpha = 1f;
        }

        Movable.parent = OriginalParent;
        Movable.position = OriginalPosition;
        Movable.rotation = OriginalRotation;
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
        Killed?.Invoke();

        elapsedTime = 0;
        while (elapsedTime < PostDeathSeconds)
        {
            if (FadeCanvas)
            {
                FadeCanvas.alpha = 1f - (elapsedTime / PostDeathSeconds);
            }
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        if (FadeCanvas)
        {
            FadeCanvas.alpha = 0f;
        }
        
        IsRespawning = false;
        Coroutine = null;
    }
}
