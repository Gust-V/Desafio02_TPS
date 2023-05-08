using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletDecal;

    private float speed = 100f;
    private float timeToDestroy = 3f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    public int targetType;

    private void OnEnable()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < .01f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Debug.Log(contact);
        if (targetType == 3)
        {
            GameObject.Instantiate(bulletDecal, contact.point + contact.normal * .0001f, Quaternion.LookRotation(contact.normal));
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }
}
