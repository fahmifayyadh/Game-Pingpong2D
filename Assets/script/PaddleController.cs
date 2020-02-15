using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float BatasAtas;
    public float BatasBawah;
    public float kecepatan;
    public string axis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        float nextpost = transform.position.y + gerak;
        if(nextpost > BatasAtas)
        {
            gerak = 0;
        }
        if (nextpost < BatasBawah)
        {
            gerak = 0;
        }
        transform.Translate(0, gerak, 0);
    }
}
