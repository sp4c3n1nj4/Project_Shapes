using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using the Text Mesh Pro Plugin for UI
using TMPro;
//suing statements to enable the saving/loading of the timeline list into/from a binary file
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

[Serializable]
public class BossFightManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hitboxes;
    [SerializeField]
    private CharacterController con;
    [SerializeField]
    private TextMeshProUGUI timerUI;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private int index = 0;
    [SerializeField]
    private float timer = 90;
    private bool fightOver = false;

    public string bossFightName = "Fight 1";
    //using a custom Unity Package myde by Textus Games (https://github.com/TextusGames/UnitySerializedReferenceUI), allows to set and save child classes in the editor
    [SerializeReference, SerializeReferenceButton]
    public List<BossAbilities> bossTimeline;

    public void SaveBossTimeline()
    {
        if (bossTimeline == null)
        {
            throw new ArgumentNullException("Timeline empty");
        }

        var surrogateSelector = new SurrogateSelector();
        surrogateSelector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), new Vector2Surrogate());

        FileStream stream = new FileStream(bossFightName, FileMode.Create);

        IFormatter formatter = new BinaryFormatter();
        formatter.SurrogateSelector = surrogateSelector;
        formatter.Serialize(stream, bossTimeline);

        stream.Close();

        Debug.Log("timeline saved");
    }

    public void LoadBossTimeline(string name)
    {
        var surrogateSelector = new SurrogateSelector();
        surrogateSelector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), new Vector2Surrogate());

        using Stream stream = File.Open(name, FileMode.Open);
        stream.Seek(0, SeekOrigin.Begin);

        IFormatter formatter = new BinaryFormatter();
        formatter.SurrogateSelector = surrogateSelector;

        bossTimeline = (List<BossAbilities>)formatter.Deserialize(stream);

        Debug.Log("timeline loaded");
    }

    private void Start()
    {
        //Ignore collision between player and enemies
        Physics.IgnoreLayerCollision(6, 7, true);

        //LoadBossTimeline(bossFightName);

        //Sort List to ensure ability to execute first is first
        bossTimeline.Sort((x, y) => x.time.CompareTo(y.time));        
    }

    private void Update()
    {
        if (bossTimeline == null || fightOver)
            return;

        //advance timer and update ui      
        timer += Time.deltaTime;
        timerUI.text = timer.ToString("N2");

        if (timer > bossTimeline[index].time)
        {
            DoAbility(bossTimeline[index]);
            index++;
        }

        if (timer > bossTimeline[bossTimeline.Count - 1].time)
        {
            EndFight();
            return;
        }
    }

    private void EndFight()
    {
        //End the fight if end of list is reached
        fightOver = true;
        Debug.LogWarning("End of Boss Timeline List reached");
    }

    private void DoAbility(BossAbilities ability)
    {
        //excecute function based on the class given and wait the delay
        if (ability.GetType() == typeof(BossMove))
        {
            var a = ability as BossMove;
            BossMoveFunction(a.moveSpeed, a.offSet, a.random, a.target);
            //StartCoroutine(DelayTimer(a.time));
        }
        else if (ability.GetType() == typeof(BossAttack))
        {
            var a = ability as BossAttack;
            BossAttackFunction(a.boxAttacks);
            //StartCoroutine(DelayTimer(a.time));
        }
    }

    private IEnumerator DelayTimer(float timer)
    {
        //wait for specified seconds
        yield return new WaitForSeconds(timer);

        //advance index and continue or end fight
        index += 1;
        if (index == bossTimeline.Count)
            EndFight();
        else
            DoAbility(bossTimeline[index]);
    }

    private Vector3 offSetVector(Vector2 offSet, Vector3 origin = new Vector3(), Vector3 start = new Vector3())
    {
        Vector3 offSet3 = new(offSet.x, 0, offSet.y);

        Vector3 direction = (origin + offSet3) - start;
        direction.y = 0;

        return direction;
    }

    private void BossMoveFunction(float duration, Vector2[] position, bool random, BossAbilityTarget target)
    {
        int j = 0;
        if (random)
        {
            j = UnityEngine.Random.Range(0, position.Length);
        }

        var motion = Vector3.zero;
        switch (target)
        {
            case BossAbilityTarget.none:
                motion = offSetVector(position[j], Vector3.zero, this.transform.position);
                break;
            case BossAbilityTarget.player:
                motion = offSetVector(position[j], player.transform.position, this.transform.position);
                break;
            case BossAbilityTarget.boss:
                motion = offSetVector(position[j]);
                break;
        }
        Debug.Log("completed boss move to: " + (motion + this.transform.position).ToString());
        con.Move(motion * duration);        
    }

    private void BossAttackFunction(HitBoxAttack[] attacks)
    {
        for (int i = 0; i < attacks.Length; i++)
        {
            int h;
            if (attacks[i].hitBoxType == HitBoxType.Cube)
                h = 0;
            else if (attacks[i].hitBoxType == HitBoxType.Cylinder)
                h = 1;
            else
                h = 2;

            int j = 0;
            if (attacks[i].random)
            {
                j = UnityEngine.Random.Range(0, attacks[i].offSet.Length);
            }

            Vector3 target = Vector3.zero;
            switch (attacks[i].target)
            {
                case BossAbilityTarget.none:
                    target = offSetVector(attacks[i].offSet[j], Vector3.zero);
                    break;
                case BossAbilityTarget.player:
                    target = offSetVector(attacks[i].offSet[j], player.transform.position);
                    break;
                case BossAbilityTarget.boss:
                    target = offSetVector(attacks[i].offSet[j], this.transform.position);
                    break;
            }

            HitBox(h, target, attacks[i]);

            Debug.Log("spawned " + attacks[i].hitBoxType.ToString() +" attack at: " + target.ToString());
        }
        
    }

    private void HitBox(int index, Vector3 target, HitBoxAttack attack)
    {
        //instantiate a hitbox and set all its variables
        GameObject b = Instantiate(hitboxes[index], target, Quaternion.Euler(0, attack.Yrotation, 0));
        b.transform.localScale = new Vector3(attack.scale.x, b.transform.localScale.y, attack.scale.y);

        b.GetComponent<HitBox>().castTime = attack.castTime;

        b.GetComponent<HitBox>().effect = attack.effect;
        b.GetComponent<HitBox>().hitBoxDuration = attack.hitBoxDuration;
        b.GetComponent<HitBox>().direction = attack.direction;
        b.GetComponent<HitBox>().damage = attack.damage;

        b.GetComponent<HitBox>().status = attack.status;
        b.GetComponent<HitBox>().statusDuration = attack.statusDuration;
        b.GetComponent<HitBox>().cleanseStatus = attack.cleanseStatus;
    }
}
