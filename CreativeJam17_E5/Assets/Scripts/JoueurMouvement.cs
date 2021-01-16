using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurMouvement : MonoBehaviour
{
    public float speed = 7f;

    float angle;
    Vector2 velocity;

    new Rigidbody2D rigidbody;

    bool peutBouger = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputDirection = new Vector2(0,0);
        if (peutBouger)
        {
            inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"),
                                      Input.GetAxisRaw("Vertical")).normalized;
        }

        if (inputDirection.magnitude != 0)
        {
            angle = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.back * angle;
        }



        velocity = transform.up * speed * inputDirection.magnitude;
    }

    private void FixedUpdate()
    {
        // Deplacement du personnage devant lui.
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
