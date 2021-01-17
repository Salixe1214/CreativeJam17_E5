using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurMouvement : MonoBehaviour
{
    public float speed = 7f;

    float angle;
    public Vector2 velocity;

    new Rigidbody2D rigidbody;

    public bool peutBouger = true;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputDirection = new Vector2(0,0);

        if (velocity == new Vector2(0, 0))
        {
            animator.SetBool("ZoeIdle", true);
        }
        else
        {
            animator.SetBool("ZoeIdle", false);
        }

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

        float niveauSpeed = transform.GetComponent<statisticsGestion>().getSpeedLevel();

        velocity = transform.up * speed * inputDirection.magnitude * niveauSpeed;
    }

    private void FixedUpdate()
    {
        // Deplacement du personnage devant lui.
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
