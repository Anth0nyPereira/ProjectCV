using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rb;

    private string targetTag;

    public bool didhit;

    public void SetTargetTag(string targetTag)
    {
        this.targetTag = targetTag;
    }

    public void Fly(Vector3 force)
    {
        rb.isKinematic = false;
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (didhit) return;
        didhit = true;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        transform.SetParent(collider.transform);
    }
}
