using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject PlayerCtrl;
    //Vector3 direction;
    public float AmountOfForce = 400;

    void OnTriggerEnter(Collider PlayerCtrl)
    {
        PlayerCtrl.gameObject.GetComponent<Rigidbody>
            ().AddForce(Vector3.up * AmountOfForce);
        //PlayerCtrl.transform.TransformDirection(Vector3.up * AmountOfForce);
    }
}
