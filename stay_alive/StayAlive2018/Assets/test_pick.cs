using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test_pick : MonoBehaviour, IPointerDownHandler // required interface when using the OnPointerDown method.
{
    RaycastHit hit;


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }

    public GameObject item;
    public GameObject item2;
    public GameObject tempParent;
    public Transform guide;
    // Use this for initialization
    void Start () {
        item.GetComponent<Rigidbody>().useGravity = false;
        item2.GetComponent<Rigidbody>().useGravity = false;
    }
	
	// Update is called once per frame
	void Update () {
       
          
    }


    void OnTriggerEnter(Collider other)
    {
        item.SetActive(true);
        if (other.gameObject.CompareTag("Bottle_v1")) {
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = guide.transform.position;
            item.transform.parent = tempParent.transform;

        }

        if (other.gameObject.CompareTag("Ground_Dirt"))
        {
            item2.GetComponent<Rigidbody>().useGravity = false;
            item2.GetComponent<Rigidbody>().isKinematic = true;
            item2.transform.position = guide.transform.position;
            item.transform.parent = tempParent.transform;

        }
    }
}
