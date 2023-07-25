using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mnj_NubeV : MonoBehaviour
{
    [HideInInspector]
    public float Tmp;
    public bool Oculta;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float VlcdEpsr = 1.8f;

        if (Oculta)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, VlcdEpsr * (Time.deltaTime * Tmp));
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), VlcdEpsr * (Time.deltaTime * Tmp));
        }
    }
}
