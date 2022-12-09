using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersBase : BaseThings
{
    public Animator animator;

    // Start is called before the first frame update
    public void AnotherStartThingy()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (transform.position.y < collision.gameObject.transform.position.y)
            {
                if (transform.position.z > collision.gameObject.transform.position.z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, collision.gameObject.transform.position.z - 0.1f);
                }
            }
            else if (transform.position.z < collision.gameObject.transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, collision.gameObject.transform.position.z + 0.1f);
            }
        }
    }

}