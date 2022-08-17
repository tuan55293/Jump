using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform[]a = GetComponentsInParent<Transform>();
        Debug.Log(a[1].name);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
