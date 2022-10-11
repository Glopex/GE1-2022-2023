using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{

    GameObject Fbody;
    GameObject Fhead;
    GameObject Ftail;
    GameObject FheadPivot;
    GameObject FtailPivot;

    public float HeadMaxAngle;
    public float TailMaxAngle;

    public float Speed;
   

    private float Xvalue;
    private float yvalue;
    // Start is called before the first frame update
    void Start()
    {
        Fbody = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Fhead = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Ftail = GameObject.CreatePrimitive(PrimitiveType.Cube);
        FheadPivot = new GameObject("head");
        FtailPivot = new GameObject("tail");

        Fbody.transform.parent = gameObject.transform;
        FheadPivot.transform.parent = gameObject.transform;
        FtailPivot.transform.parent = gameObject.transform;
        Fhead.transform.parent = FheadPivot.transform;
        Ftail.transform.parent = FtailPivot.transform;

        
        Fbody.transform.localScale = new Vector3(1, 0.5f, 0.5f);
        Fhead.transform.localScale = new Vector3(1, 0.5f, 0.5f);
        Ftail.transform.localScale = new Vector3(1, 0.5f, 0.5f);

        Fbody.transform.position = new Vector3(0, 0, 0);
        FheadPivot.transform.position = new Vector3(0.5f, 0, 0);
        FtailPivot.transform.position = new Vector3(-0.5f, 0, 0);
        Fhead.transform.localPosition = new Vector3(0.5f, 0, 0);
        Ftail.transform.localPosition = new Vector3(-0.5f, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Xvalue += 1 * Speed;
        float angletousehead = HeadMaxAngle*(Mathf.Sin(Xvalue));
        float angletousetail = TailMaxAngle * (Mathf.Sin(Xvalue)*-1);
        FheadPivot.transform.localRotation = Quaternion.AngleAxis(angletousehead,Vector3.forward);
        FtailPivot.transform.localRotation = Quaternion.AngleAxis(angletousetail*-1, Vector3.forward);
    }
}
