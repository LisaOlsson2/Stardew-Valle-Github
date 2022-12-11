using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersBase : BaseThings
{
    public Animator animator;
    static int limit = -1;

    // Start is called before the first frame update
    public void AnotherStartThingy()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (Mathf.Abs(transform.position.z) > Mathf.Abs(limit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                limit = -limit;
            }

            if (transform.position.y * limit < collision.transform.position.y * limit && transform.position.z * limit >= collision.transform.position.z * limit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, collision.transform.position.z - 0.1f * limit);
            }
        }
    }
}