using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    //variables set on Instatiate
    public float castTime;

    public HitBoxEffect[] effect;
    public float hitBoxDuration;
    public Vector2 direction;
    public float damage;

    public StatusEffectData[] status;
    public float statusDuration;
    public StatusEffectData[] cleanseStatus;

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

        var per = timer / castTime;
        per = Mathf.Clamp(per, 0, 1);
        material.SetFloat("_Fill_Rate", per);

        CheckCollision();
    }

    private void CheckCollision()
    {
        if (timer >= castTime)
        {
            material.SetColor("_Fill_Colour", completeColor);

            bool isTower = UnityEditor.ArrayUtility.Contains(effect, HitBoxEffect.tower);   

            if ((playerIn && !isTower) || (!playerIn && isTower))
            {
                PlayerHit();
                stop = true;
                StartCoroutine(castTimerReached());
            }
            else
                StartCoroutine(castTimerReached());
        }
    }

    private void PlayerHit()
    {
        print("player hit");

        if (UnityEditor.ArrayUtility.Contains(effect, HitBoxEffect.damage))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        if (UnityEditor.ArrayUtility.Contains(effect, HitBoxEffect.knockback))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().Move(direction);
        }
    }

    private void ApplyStatus()
    {

    }

    private IEnumerator castTimerReached()
    {
        if (effect == null)
        {
            Destroy(gameObject, 0.5f);
        }

        if (UnityEditor.ArrayUtility.Contains(effect, HitBoxEffect.continous))
        {
            yield return new WaitForSeconds(hitBoxDuration);
        }

        Destroy(gameObject, 0.5f);
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
