using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //public float minimum = -3.0f;
    //public float maximum = 3.0f;

    //private static float t = 0.0f;

    //private void FixedUpdate()
    //{
    //    Vector2 newPos = transform.localPosition;
    //    newPos.x = Mathf.Lerp(minimum, maximum, t);

    //    transform.localPosition = newPos;

    //    t += 0.5f * Time.fixedDeltaTime;

    //    if (t > 3.0f)
    //    {
    //        float temp = maximum;
    //        maximum = minimum;
    //        minimum = temp;
    //        t = 0.0f;
    //    }
    //}


    public float HeroDetectRadius = 2f; // Khoang cach nhan biet cua bot
    public float StopDistance = 0.2f;
    public Transform target;
    private Vector2 destination;
    private Rigidbody2D rb;


    public float moveSpeed = 2f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    private void FixedUpdate()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= HeroDetectRadius && distance >= StopDistance)
        {
            Move();
        }
    }


    private void Move()
    {
        
        destination.x = target.position.x - transform.position.x;
        destination.y = target.position.y - transform.position.y;
        rb.MovePosition(rb.position + destination * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, HeroDetectRadius);
    }



}
