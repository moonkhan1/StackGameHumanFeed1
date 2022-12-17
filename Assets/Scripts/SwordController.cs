using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwordController : MonoBehaviour
{
    private Transform _transform;
    private Transform _movePos;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _movePos = GetComponent<Transform>().GetChild(0);
         _transform.DORotate(new Vector3(_movePos.position.x*-1.5f,0,0), 0.8f, RotateMode.Fast)
        .SetLoops(-1, LoopType.Yoyo)
        .SetRelative()
        .SetEase(Ease.Linear);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
