using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mnj_Nube : MonoBehaviour
{
    public GameObject MdlNube;


    // Start is called before the first frame update
    void Start()
    {
        int rndm = Random.Range(0, MdlNube.transform.childCount - 1);
        MdlNube.transform.GetChild(0).gameObject.SetActive(false);
        MdlNube.transform.GetChild(rndm).gameObject.SetActive(true);
    }
}
