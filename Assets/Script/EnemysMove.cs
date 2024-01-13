using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysMove : MonoBehaviour
{
    public Transform pos1, pos2, startPos;
    Vector3 nextPos;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        else if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}


