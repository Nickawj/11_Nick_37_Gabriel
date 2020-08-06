using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float translation = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            transform.Translate(translation, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float translation = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            transform.Translate(translation, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            SceneManager.LoadScene("Win");
        }

        if (collision.gameObject.tag == "Lose")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
