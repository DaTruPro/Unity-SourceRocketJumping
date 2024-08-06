using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProj : MonoBehaviour
{
    public GameObject blast;
    GameObject blastInstance;
    RaycastHit hit;
    //public Mesh myMesh;
    //public Texture myTexture;
    private void Start()
    {
        //myMesh = Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "ProjComponent")
        {
            ContactPoint contact = collision.contacts[0];
            //Debug.Log(collision.gameObject.transform);
            //Debug.Log(collision.gameObject.GetComponentInParent<Transform>());
            /*
            blast = new GameObject("Blast");
            ///Mesh///
            blast.AddComponent<MeshFilter>();
            blast.GetComponent<MeshFilter>().mesh = myMesh;
            blast.AddComponent<MeshRenderer>();
            //blast.GetComponent<MeshRenderer>().material = myTexture;
            ///Scripts///
            blast.AddComponent<Knockback>();
            blast.GetComponent<Knockback>().force = 200;
            ///Colliders///
            blast.AddComponent<SphereCollider>();
            blast.GetComponent<SphereCollider>().isTrigger = true;
            blast.GetComponent<SphereCollider>().radius = 1f;
            
            GetComponent<Collider>().enabled = false;
            */
            blastInstance = Instantiate(blast, contact.point, transform.rotation);
            //blast.transform.position = contact.point;
            //if (Physics.SphereCast(blast.transform.position, 10f, Vector3.forward, out hit, 3)) {
            //    Debug.Log("hit");
            //    blast.transform.position = new Vector3 (blast.transform.position.x, hit.transform.position.y, blast.transform.position.z);
                //Vector3.MoveTowards(blast.transform.position, hit.transform.position, 100000000);
            //}

            ///Destroy Original///
            Destroy(gameObject);
        }
    }
}
