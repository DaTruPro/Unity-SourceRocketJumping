using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour

{
    
    //private MoveData _moveData = new MoveData();
    //public Rigidbody rb;
    private Collider collide;
    //private GameObject empty;
    public Vector3 distanceBetween;
    //[SerializeField] public Collider radius;
    [SerializeField] public int force;
    private float speed;
    private void Start()
    {

    }
    private void Update()
    {

        StartCoroutine(destroyBlast());
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collision");
        if(!other.CompareTag("Player"))
        {
            //distanceBetween = transform.position;
            //distanceBetween = new Vector3(transform.position.x - other.transform.position.x, transform.position.y - other.transform.position.y, transform.position.z - other.transform.position.z);
            //other.GetComponent<Rigidbody>().AddForce(distanceBetween * -force);
            //rb.AddForce (force,0,0);
            //transform.position = rb.position;
            //Debug.Log("aaa");
            //other.transform.GetComponent<Player_Movement>().isKnocked = true;)
            if (other.transform.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddExplosionForce(force, transform.position, 1);
            }
        }
        if(other.CompareTag("Player"))
        {
            other.transform.GetComponentInParent<Fragsurf.Movement.SurfCharacter>().moveData.isKnocked = true;
            //other.GetComponentInParent<Rigidbody>().AddForce(distanceBetween * -force);
            other.transform.GetComponentInParent<Fragsurf.Movement.SurfCharacter>().moveData.distanceBetween = 
                new Vector3(transform.position.x - other.transform.parent.transform.GetChild(2).position.x, transform.position.y - other.transform.parent.transform.GetChild(2).position.y, transform.position.z - other.transform.parent.transform.GetChild(2).position.z);
            //Debug.Log(other.transform.GetComponentInParent<Fragsurf.Movement.SurfCharacter>().moveData.distanceBetween);
        }
    }

    IEnumerator destroyBlast()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }


}
