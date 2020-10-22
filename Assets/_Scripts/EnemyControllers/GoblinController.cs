using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GoblinController : MonoBehaviour
{
    public Animator animator;

    public GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check distance to player if within certain amount
        if(math.distance(playerCharacter.transform.position.x, transform.position.x) < 200)
        {
            Debug.Log("InRange");

        }
    }
}
