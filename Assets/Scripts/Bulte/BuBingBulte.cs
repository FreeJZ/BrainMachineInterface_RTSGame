using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuBingBulte : MonoBehaviour
{
    public float moveSpeed;
    private ArmBase user;
    private CapsuleCollider col;
    private Transform atkTarget;
    private LayerMask atkLayer;
    private Rigidbody rb;
    void Start()
    {
        col = GetComponentInChildren<CapsuleCollider>();
        rb = GetComponent<Rigidbody>(); 
    }
    public void Init(ArmBase user,Transform atkTarget,LayerMask atkLayer)
    {
        this.user = user;
        this.atkTarget = atkTarget;
        this.atkLayer = atkLayer;
    }
    private void Update()
    {
        rb.velocity = (atkTarget.position - transform.position).normalized*moveSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rb.velocity.normalized), Time.deltaTime * 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer == atkLayer)
        {
            Debug.Log("¹¥»÷" + other.name);
            IHurt hurt = other.GetComponentInChildren<IHurt>();
            hurt.Hurt(user);

            rb.velocity = Vector3.zero;
            PoolMgr.Instance.PushObj(this.gameObject);
        }
    }
}
