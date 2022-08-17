using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Ins.mainCam)
        {
            transform.position = new Vector3(
                GameManager.Ins.mainCam.transform.position.x, 
                GameManager.Ins.mainCam.transform.position.y,0f
                );
        }
    }
}
