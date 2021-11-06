using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    //[SerializeField]
    
    bool detected = false;
    //[SerializeField]
    
    [SerializeField]
    public Transform Waypoint1;
    [SerializeField]
    public Transform Waypoint2;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    GameObject target;
    GameObject sound;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0];
        sound = GameObject.FindGameObjectsWithTag("Sound")[0];
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    bool CanSeePlayer(float distance)
    {
        float castDist = distance;

        Vector2 endPos = transform.position + -this.gameObject.transform.up * distance;

        RaycastHit2D hit = Physics2D.Linecast(transform.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                detected = true;
                print("I FoUNd YoU");
                return true;
            }
        }
        Debug.DrawLine(transform.position, endPos, Color.red);
        return false;
    }

    void CanHearPlayer()
    {
        if (sound.GetComponentInChildren<CircleCollider2D>().IsTouching(this.gameObject.GetComponentInChildren<CircleCollider2D>()))
        {
            detected = true;
        }
    }

    void facePlayer()
    {
        var offset = 90f;
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, target.transform.position);
        print(distToPlayer);
        CanHearPlayer();
        CanSeePlayer(5);
        if (detected == true)
        {
            if (CanSeePlayer(5)==true && distToPlayer <= 5)
            {
                return;
            }
            if (path == null)
                return;

            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }
            facePlayer();
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            return;
        }
    }
}
