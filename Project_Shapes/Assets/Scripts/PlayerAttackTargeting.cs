using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTargeting : MonoBehaviour
{
    public float minTargetDistance;
    public GameObject model;
    public CharacterController player;
    public float turnTimer = 0.5f;

    private float timer = 0f;
    private float oldTargetingRotation = 0;
    
    //find nearest target enemy 
    void Update()
    {
        TargetEnemy(FindClosestEnemy());
    }

    private GameObject FindClosestEnemy()
    {
        GameObject target = null;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        var distance = minTargetDistance;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, enemies[i].transform.position) < distance)
                target = enemies[i];
        }

        return target;
    }

    //turn character towards enemy or in movement direction
    private void TargetEnemy(GameObject target)
    {
        //if ther are no enemies nearby, player turns back towards movement direction
        if (target == null)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            timer = Mathf.Clamp(timer, 0, 1);
        }
        else
        {
            timer = turnTimer;

            Vector3 targetVector = target.transform.position - this.transform.position;
            oldTargetingRotation = Mathf.Rad2Deg * Mathf.Atan2(targetVector.x, targetVector.z);
        }
        //todo: lerp movemen rotation with current rotation
        float movementRotation = Mathf.Rad2Deg * Mathf.Atan2(player.velocity.x, player.velocity.z);

        float lerpRotation = Mathf.LerpAngle(movementRotation, oldTargetingRotation, timer);

        model.transform.rotation = Quaternion.AngleAxis(lerpRotation, Vector3.up);

        //place targeting animation
    }

    private void OnDrawGizmos()
    {
        //debug gizmos to visualize targeting enemies
        GameObject target = FindClosestEnemy();

        if (target == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, target.transform.position);
    }
}
