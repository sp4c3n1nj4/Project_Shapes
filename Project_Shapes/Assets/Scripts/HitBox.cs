using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float time;
    public float damage;

    private float timer = 0;
    private Material material;

    [SerializeField]
    private bool cube;
    [SerializeField]
    private Color completeColor;
    private bool playerIn = false;
    private bool stop = false;

    private void Awake()
    {
        //get reference to object material
        material = gameObject.GetComponent<MeshRenderer>().material;

        if (!cube)
        {
            material.SetFloat("_Fill_Value", 1);
        }    
    }

    private void Update()
    {
        if (stop)
            return;

        //advance timer and display it on the material
        timer += Time.deltaTime;

        var per = timer / time;
        per = Mathf.Clamp(per, 0, 1);
        material.SetFloat("_Fill_Rate", per);

        if (timer >= time)
        {
            material.SetColor("_Fill_Colour", completeColor);
            if (playerIn)
            {
                PlayerHit();
                stop = true;
                Destroy(gameObject, 0.5f);
            }
            else
                Destroy(gameObject, 0.5f);
        }
    }

    private void PlayerHit()
    {
        print("player hit");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerIn = false;
    }

}
