using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    public Animator animator;
    public float speed = 5;
    public GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = math.distance(playerCharacter.transform.position.x, transform.position.x);

        //check distance to player if within certain amount
        if (distance < 10 && distance > 1)
        {
            //Debug.Log("InRange");
            float direction = playerCharacter.transform.position.x - transform.position.x;
            math.clamp(direction, -1, 1);
            transform.position += (new Vector3(direction * speed * Time.deltaTime, 0.0f, 0.0f));
            animator.SetFloat("Speed", math.abs(direction));

        }
        else if(distance < 1)
        {
            animator.SetFloat("Speed", 0);
            Attack();
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void Attack()
    {
        if(!animator.GetBool("IsAttacking"))
        {
            Debug.Log("Attacking");

            animator.SetBool("IsAttacking", true);
        }
    }
}
