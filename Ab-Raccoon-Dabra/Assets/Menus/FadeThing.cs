using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeThing : MonoBehaviour {

    private void Start()
    {
        gameObject.GetComponent<Animator>().SetTrigger("fade");
    }
}
