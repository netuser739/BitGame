using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private int _health = 10;
    [SerializeField] public int _harm = 2;
    [SerializeField] private Animator animator;
    private Transform target;
    Rigidbody2D enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Vector3 mov = dir * _speed;

        animator.SetFloat("Horizontal", mov.x);
        animator.SetFloat("Vertical", mov.y);
        animator.SetFloat("Speed", mov.sqrMagnitude);

        if (mov != Vector3.zero)
        {
            enemy.MovePosition(transform.position + mov * Time.deltaTime);
        }
    }
}
