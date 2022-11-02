using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animations : MonoBehaviour
{
    public Transform[] moveHexas;
    void Start()
    {
        moveHexas[0].DOMoveX(7.91f, 2f).SetLoops(-1, LoopType.Yoyo);
        moveHexas[1].DOMoveX(-3f, 2f).SetLoops(-1, LoopType.Yoyo);

    }
    
    
}
