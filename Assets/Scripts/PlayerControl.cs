using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Animator animator;
    [SerializeField] private int _health = 10;
    Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-6f, (float)-3.5, 0f);
        //var harm = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyControl>();


    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mov = new Vector3(Input.GetAxis("Horizontal") * _speed, Input.GetAxis("Vertical") * _speed, 0);
        mov = Vector3.ClampMagnitude(mov, _speed);

        animator.SetFloat("Horizontal", mov.x);
        animator.SetFloat("Vertical", mov.y);
        animator.SetFloat("Speed", mov.sqrMagnitude);


        if (mov != Vector3.zero)
        {
            player.MovePosition(transform.position + mov * Time.deltaTime);
        }

        Debug.Log(_health);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") StartCoroutine(Damage(2));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            StopAllCoroutines();
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if(other.gameObject.tag == "Enemy")
    //    {
    //        StartCoroutine((IEnumerator)Damage(2));
    //    }
    //}

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        StopAllCoroutines();
    //    }
    //}

    private IEnumerator Damage(int harm)
    {
        while (_health > 0)
        {
            _health -= harm;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
