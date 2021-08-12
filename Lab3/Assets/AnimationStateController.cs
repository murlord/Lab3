using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int RunningHash;
    public float Health = 1;
    public Transform punchPoint;
    public Transform kickPoint;
    public float attackRange = 0.5f;

    public LayerMask whatIsEnemy;


     public bool IsDead
    {
        get 
        {
            return Health == 0;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        RunningHash = Animator.StringToHash("Running");
    }

    // Update is called once per frame
    void Update()
    {
        bool Running = animator.GetBool(RunningHash);
        bool forwardPressed = Input.GetKey("w");
        bool punchPressed = Input.GetKey("j");
        bool kickPressed = Input.GetKey("k");
        if (!Running && forwardPressed)
        {
            animator.SetBool(RunningHash, true);
        
        }
        if (Running && !forwardPressed)
        {
            animator.SetBool(RunningHash, false);

        }
        if (punchPressed);
        {
            animator.SetBool("Punching", true);
            Collider[] hitEnemies = Physics.OverlapSphere(punchPoint.position, attackRange, whatIsEnemy);
            foreach (Collider enemy in hitEnemies)
            {
                Debug.Log("hit" + enemy.name);
            }
        }

        if (!punchPressed)
        {
            animator.SetBool("Punching", false);

        }

        if (kickPressed)
        {
            animator.SetBool("Kicking", true);

        }
        if (!kickPressed)
        {
            animator.SetBool("Kicking", false);

        }
        if (Health <= 0)
        {
            animator.SetBool("Death", true);
        }


    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health--;
            
        }
    }

    private void OnDrawGizmosSelected()
    {

        if (punchPoint == null)
            return;
        
        
        Gizmos.DrawSphere(punchPoint.position, attackRange);
    }
}
