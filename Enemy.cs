using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int EnemyHealth, Damage;
    public Inventory inventory;
    public Collider2D EnemyCollider;
    public bool IsConstantMover, IsFollower, FacingRight;
    public float Speed;
    private Rigidbody2D EnemyRigidbody2D;

    private void Awake()
    {
        EnemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        EnemyConstantMove(IsConstantMover);
        FollowPlayer(IsFollower);

    }

    public void OnTriggerEnter2D(Collider2D EnemyCollider)
    {
        if (EnemyCollider.CompareTag("Player"))
        {
            inventory.Hurt(Damage);
        }
        if (EnemyCollider.CompareTag("Weapon"))
        {
            EnemyHurt(inventory.PlayerAttack);
        }
        if (EnemyCollider.CompareTag("Turn"))
        {
            Flip();
        }

    }

    public void EnemyHurt(int PlayerDamage)
    {
        if (PlayerDamage >= EnemyHealth)
        {
            Destroy(gameObject);
        }
        else
        {
            EnemyHealth -= PlayerDamage;
        }
    }

    public void EnemyConstantMove(bool Move)
    {
        if (Move)
        {
            EnemyRigidbody2D.velocity = new Vector2(Speed, 0.0f);
        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        // Multiply the enemy's x local scale by -1.
        Vector3 TheScale = transform.localScale;
        TheScale.x *= -1;
        transform.localScale = TheScale;
        Speed = Speed * -1;
    }

    public void FollowPlayer(bool Follow)
    {
        if (Follow)
        {
            
        }
    }
}
