using UnityEngine;
using System.Collections;

public class Boss2 : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject hero;

    float originalSpeed;
    public float slowSpeedMulti = 0.7f;
    public float slowTime = 5;
    public float chargeSpeedMulti = 2f;

    float timer;

    float rayHeight;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hero = GameObject.FindGameObjectWithTag("Player");

        originalSpeed = agent.speed;
        agent.destination = hero.transform.position;
        rayHeight = hero.transform.position.y + hero.GetComponent<Renderer>().bounds.size.y;

    }

    void Update()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            agent.destination = hero.transform.position;
        }

        Timer();

        if (LineOfSight() && timer <= 0)
        {
            agent.speed = originalSpeed * chargeSpeedMulti;
        }
        else if (agent.speed != originalSpeed && timer <= 0)
        {
            agent.speed = originalSpeed;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == hero)
        {
            agent.speed = originalSpeed * slowSpeedMulti;
            timer = slowTime;
        }
    }

    void Timer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }


    bool LineOfSight()
    {
        Ray eyesForward = new Ray(new Vector3(transform.position.x, rayHeight, transform.position.z), Vector3.forward);
        Ray eyesRight = new Ray(new Vector3(transform.position.x, rayHeight, transform.position.z), Vector3.right);
        Ray eyesBack = new Ray(new Vector3(transform.position.x, rayHeight, transform.position.z), Vector3.back);
        Ray eyesLeft = new Ray(new Vector3(transform.position.x, rayHeight, transform.position.z), Vector3.left);
        RaycastHit hit;

        if (Physics.Raycast(eyesForward, out hit, Mathf.Infinity) && hit.transform.gameObject == hero || Physics.Raycast(eyesRight, out hit, Mathf.Infinity) && hit.transform.gameObject == hero || Physics.Raycast(eyesBack, out hit, Mathf.Infinity) && hit.transform.gameObject == hero || Physics.Raycast(eyesLeft, out hit, Mathf.Infinity) && hit.transform.gameObject == hero)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
