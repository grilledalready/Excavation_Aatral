using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using static Enums;

public class PPESlot : MonoBehaviour
{
    public PPE ppeSlot;

    public Transform followObject;

    private void Update()
    {
        transform.position = followObject.position;
        transform.rotation = followObject.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PPE"))
        {
            if (other.gameObject.GetComponent<PPEObject>() != null)
            {
                if (other.gameObject.GetComponent<PPEObject>().ppeName == ppeSlot)
                {
                    //Equip PPE
                    Destroy(other.gameObject.GetComponent<XRGrabInteractable>());
                    Destroy(other.gameObject.GetComponent<XRGeneralGrabTransformer>());
                    Destroy(other.gameObject.GetComponent<Rigidbody>());

                    other.gameObject.transform.parent = this.transform;
                    other.gameObject.transform.localPosition = Vector3.zero;
                    other.gameObject.transform.localEulerAngles = Vector3.zero;
                }
            }
        }
    }
}
