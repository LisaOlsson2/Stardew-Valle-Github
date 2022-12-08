using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LilCreditsDude : MonoBehaviour
{
    InfoToSave book;

    float speed = 8;
    bool grounded;
    bool interactable;

    // Start is called before the first frame update
    void Start()
    {
        book = FindObjectOfType <InfoToSave>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") && transform.position.x > -8)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey("right") && transform.position.x < 8)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKeyDown("up"))
        {
            if (grounded)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
                grounded = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.X) || (interactable && Input.GetKeyDown(KeyCode.Z)))
        {
            Destroy(book.gameObject);
            SceneManager.LoadScene("Start");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    // Ontriggerstay didn't always detect the input

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactable = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = false;
    }
}