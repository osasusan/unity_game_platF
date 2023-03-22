using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMuve : MonoBehaviour
{
    Rigidbody cuerpo;
    
   [SerializeField] float speed = 6f;
   [SerializeField] float jumpForce = 4f;

   [SerializeField] Transform check;
   [SerializeField] LayerMask suelo;
   [SerializeField] AudioSource jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        cuerpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalIn = Input.GetAxis("Horizontal");  
        float verticalIn = Input.GetAxis("Vertical");

        cuerpo.velocity = new Vector3(horizontalIn * speed, cuerpo.velocity.y, verticalIn * speed);

        if (Input.GetButtonDown("Jump") && EnSuelo())
        {
            Jump();
        }
    }
    void Jump()
    {
        cuerpo.velocity = new Vector3(cuerpo.velocity.x, jumpForce, cuerpo.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool EnSuelo()
    {
        return Physics.CheckSphere(check.position, .1f, suelo);
       
    }
}
