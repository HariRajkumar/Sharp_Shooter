using NUnit.Framework;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] GameObject projectileHitVFX;
    Rigidbody rb;
    int damage;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);
        Instantiate(projectileHitVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    /*
    [SerializeField] int damage = 2;
    Rigidbody rb;
    PlayerHealth player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindFirstObjectByType<PlayerHealth>();
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * 5;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
    */

}
