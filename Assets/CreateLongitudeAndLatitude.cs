using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest;

public class CreateLongitudeAndLatitude : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject TheSun;
    private float Radius = 9f;
    //private float resol = 360;
    float ViToaDo = 90f;
    float KinhToado = 0f;
    bool HuongBac, HuongNam, HuongTay, HuongDong;

    void Start()
    {
        HuongBac = true;HuongDong = true;
        GetPositionTheSun();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPositionTheSun()
    {
        if (HuongBac)
        {
            ViToaDo = Mathf.Abs(ViToaDo);
        }
        else ViToaDo = -ViToaDo;

        if (HuongDong) KinhToado = Mathf.Abs(KinhToado);
        else KinhToado = -KinhToado;


        float ridiusViDo = Radius * Mathf.Sin(((90 - ViToaDo) * (2f * Mathf.PI)) / 360);
        float Giam = Radius * Mathf.Cos((90 - ViToaDo) * (2f * Mathf.PI / 360));
        float x = ridiusViDo * Mathf.Cos(KinhToado * (2f * Mathf.PI / 360));
        float y = ridiusViDo * Mathf.Sin(KinhToado * (2f * Mathf.PI / 360));
        Debug.Log("DO DAI : " + ridiusViDo);
        Debug.Log("DO DAI Giam : " + Giam);
        Debug.Log("DO DAI TONG : " + (Giam + ridiusViDo));

        Vector3 poin = new Vector3(x, Giam, y);
        TheSun.transform.position = poin;
    }
}
