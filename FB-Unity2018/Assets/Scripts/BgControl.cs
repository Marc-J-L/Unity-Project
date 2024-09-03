using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    public float speed = 0.3f;
    public float width = 5.8f;

    public bool isMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMove) return;

        foreach(Transform trans in transform)
        {
            Vector3 v = trans.position;
            v.x -= speed * Time.deltaTime;
            if(v.x < -width)
            {
                v.x += width * 2;
            }
            trans.position = v;
        }
    }
}
