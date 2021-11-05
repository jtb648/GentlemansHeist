using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    bool detected = false;
    public Transform sound;
    public Transform Waypoint1;
    public Transform Waypoint2;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    [SerializeField]
    public Transform castPoint;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void CanSeePlayer(float distance)
    {
        float castDist = distance;

        Vector2 endPos = castPoint.position + -this.gameObject.transform.up * distance;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                detected = true;
                print("I FoUNd YoU");
            }
        }

        Debug.DrawLine(castPoint.position, endPos, Color.red);
    }

    void facePlayer()
    {
        var offset = 90f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sound.GetComponentInChildren<CircleCollider2D>().IsTouching(this.gameObject.GetComponentInChildren<CircleCollider2D>()))
        {
            detected = true;
        }
        CanSeePlayer(5);
        if (detected == true)
        {
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
