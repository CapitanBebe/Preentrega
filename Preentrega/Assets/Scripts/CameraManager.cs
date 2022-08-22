using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{//Propiedades
    public GameObject[] vistas;
    public bool YesOrNo = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (YesOrNo == true)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                vistas[0].SetActive(true);
                vistas[1].SetActive(false);
                YesOrNo = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                vistas[0].SetActive(false);
                vistas[1].SetActive(true);
                YesOrNo = true;
            }
        }
    }
}
