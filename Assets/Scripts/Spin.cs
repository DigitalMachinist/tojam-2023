using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float RotatePeriodSeconds = 4f;
    public float BobPeriodSeconds = 1f;
    public float BobMagnitude = 0.5f;
        
    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), RotatePeriodSeconds, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
        transform.DOMoveY(transform.position.y + BobMagnitude, BobPeriodSeconds).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
