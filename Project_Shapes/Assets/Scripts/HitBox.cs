using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float time;
    public float damage;

    private float timer = 0;
    private Material material;

    private void Awake()
    {
        //get reference to object material
        material = gameObject.GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        //advance timer and display it on the material
        timer += Time.deltaTime;

        var per = timer / time;
        per = Mathf.Clamp(per, 0, 1);
        material.SetFloat("_Fill_Rate", per);
    }

    private void EndHitbox(GameObject hit)
    {
        //deal damage to player

        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        //detect if the player is inside hit at the specified time
        if (other.gameObject.CompareTag("Player") && timer >= time)
        {
            EndHitbox(other.gameObject);
        }
    }

}
