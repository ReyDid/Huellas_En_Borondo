using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Objetos : MonoBehaviour
{
    public string Tipo;
    public bool Valido;

    [Header("General")]
    public GameObject _Objeto;
    public bool Dstr;
    public int rndmVlcd;
    bool RyHch;

    [Header("Composicion")]
    public Collider Clsn_Cmp;
    public RaycastHit Ry;
    public float DstncRy;
    public LayerMask Solido;

    [Header("Referencias")]
    public NoColision _NoColision;
    public TipoObjeto _Tipo;
    [HideInInspector]
    public Rigidbody CrpRgd;

    [System.Serializable]
    public class NoColision
    {
        public bool Intr;
        public Collider Clsn;
        public Transform DstncObjtv_1;
        public Transform DstncObjtv_2;

        public GameObject Objt_S;
        public GameObject Objt_N;

        public GameObject[] Objt;

        public float Dstnc_1;
        public float Dstnc_2;
    }
    [System.Serializable]
    public class TipoObjeto
    {
        public int Cntd;
    }

    // Start is called before the first frame update
    void Start()
    {
        CrpRgd = GetComponent<Rigidbody>();

        if (rndmVlcd != -1)
        {
            rndmVlcd = Random.Range(1, 5);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        switch (Tipo)
        {
            case "Huella":
                Huella();
                _Tipo.Cntd = 5;
                break;
            case "Letra":
                Letra();
                break;
            case "Coleccion de Huellas":
                _Tipo.Cntd = 25;
                break;
        }
        Clsn_Cmp.enabled = Valido;

        //Gravedad();
        if (!RyHch)
        {
            Rayo();
            RyHch = true;
        }

        if (Dstr)
        {
            Destruir();
        }
    }


    void Rayo()
    {
        CrpRgd.useGravity = false;
        CrpRgd.isKinematic = true;

        if (Physics.Raycast(transform.position, -Vector3.up, out Ry, DstncRy, Solido))
        {
            //Debug.DrawLine(transform.position, Ry.point, Color.green);
            _Objeto.transform.position = Ry.point;
        }
    }
    void Gravedad()
    {
        float vlcd = 0;
        switch (rndmVlcd)
        {
            case -1:
                vlcd = 200;
                break;
            case 1:
                vlcd = 100;
                break;
            case 2:
                vlcd = 130;
                break;
            case 3:
                vlcd = 180;
                break;
            case 4:
                vlcd = 150;
                break;
            case 5:
                vlcd = 111;
                break;
        }

        CrpRgd.velocity = Vector3.zero + (transform.up * -vlcd);
    }



    void Huella()
    {
        if (_NoColision.Intr)
        {
            _NoColision.Objt_N.SetActive(false);
            _NoColision.Objt_S.SetActive(true);
            _Objeto.transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else
        {
            _NoColision.Objt_N.SetActive(true);
            _NoColision.Objt_S.SetActive(false);
        }
    }
    void Letra()
    {
        if (!RyHch)
        {
            _NoColision.Objt[0].SetActive(name == "B");
            _NoColision.Objt[1].SetActive(name == "O_1");
            _NoColision.Objt[2].SetActive(name == "R");
            _NoColision.Objt[3].SetActive(name == "O_2");
            _NoColision.Objt[4].SetActive(name == "N");
            _NoColision.Objt[5].SetActive(name == "D");
            _NoColision.Objt[6].SetActive(name == "O_3");
        }
    }




    public void Destruir()
    {
        _Objeto.transform.localPosition = Vector3.zero;
        _Objeto.transform.localScale = new Vector3(1, 1, 1);

        if (_NoColision.Clsn != null)
        {
            _NoColision.Objt_N.SetActive(true);
            _NoColision.Objt_S.SetActive(false);
        }

        RyHch = false;
        _NoColision.Intr = false;
        gameObject.SetActive(false);
        Dstr = false;
    }
}
