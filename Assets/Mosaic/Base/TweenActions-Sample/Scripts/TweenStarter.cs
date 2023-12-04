using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenStarter : MonoBehaviour
{
    [SerializeField] Mosaic.Base.TweenActions.TweenActionCore action;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            action.Act(this.gameObject);
    }
}
