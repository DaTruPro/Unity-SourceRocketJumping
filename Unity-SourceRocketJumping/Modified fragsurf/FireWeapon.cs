using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    //[SerializeField] public Rigidbody Proj;
    public GameObject Proj;
    GameObject projInstance;
    //GameObject Head;
    //GameObject currentProj;
    //public Mesh myMesh;
    //public GameObject meshObject;
    //public Mesh myMesh;
    //public Material myTexture;
    private bool clipping = false;
    // Start is called before the first frame update
    void Start()
    {
        //meshObject = Resources.Load<GameObject>("rocket");
        //myMesh = meshObject.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh;
        //myTexture = meshObject.transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;
        //Debug.Log(myMesh);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Terrain"))
        {
            clipping = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (clipping)
        {
            clipping = false;
        }
    }
    void Update()
    {
        //Debug.Log(clipping);
        //Debug.Log(transform.position.y);
        //Debug.Log(transform.parent.position.y);
        //Debug.Log(myMesh);
        //Quaternion num = Proj.rotation;
        if (Input.GetButtonDown("Fire1"))
        {
            /*
            Proj = new GameObject("Proj");
            Head = new GameObject("Head");
            ///Meshes///
            Proj.AddComponent<MeshFilter>();
            Proj.GetComponent<MeshFilter>().mesh = myMesh;
            Proj.AddComponent<MeshRenderer>();
            Proj.GetComponent<MeshRenderer>().material = myTexture;
            ///Rigidbody///
            Proj.AddComponent<Rigidbody>();
            Proj.GetComponent<Rigidbody>().useGravity = false;
            Proj.GetComponent<Rigidbody>().transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
            ///Scripts///
            Proj.AddComponent<DestroyProj>();
            ///Colliders///
            Proj.AddComponent<CapsuleCollider>();
            Proj.GetComponent<CapsuleCollider>().isTrigger = false;
            Proj.GetComponent<CapsuleCollider>().radius = 1;
            Proj.GetComponent<CapsuleCollider>().height = 4;
            Proj.GetComponent<CapsuleCollider>().direction = 2;
            */
            //projInstance = Instantiate(Proj);
            //Proj.layer = (9);

            //Head.transform.parent = Proj.transform;
            //Head.transform.localPosition = new Vector3(0, 0, 2);
            ///Align with current posistion and rotation then add veloctiy///
            if (clipping)
            {
                //projInstance.GetComponent<Rigidbody>().transform.SetPositionAndRotation(new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), transform.parent.rotation);
                projInstance = Instantiate(Proj, new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z), transform.parent.rotation);

            }
            else
            {
                projInstance = Instantiate(Proj, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.parent.rotation);
            }
            projInstance.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 20);
            //Proj.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(20, 20, 20));
            //Debug.Log(Proj.GetComponent<Rigidbody>().velocity);
        }
    }
}
