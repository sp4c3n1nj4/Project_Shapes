using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HitBoxVisualizer : MonoBehaviour
{
    [SerializeField]
    private GameObject RectangleSprite;
    [SerializeField]
    private GameObject CircleSprite;

    [SerializeField]
    private GameObject worldCanvas;

    private Dictionary<Collider, GameObject> visualizers = new Dictionary<Collider, GameObject> { };

    private void Update()
    {
        UpdateHitBoxes(FindHitBoxes());
    }

    //return all box or sphere colliders that are triggers in the current scene
    private Collider[] FindHitBoxes()
    {
        List<Collider> colliders = new List<Collider> { };
        Collider[] hitBoxes = GameObject.FindObjectsOfType<Collider>(false);

        for (int i = 0; i < hitBoxes.Length; i++)
        {
            if (hitBoxes[i].isTrigger && (hitBoxes[i] is BoxCollider || hitBoxes[i] is SphereCollider))
            {
                colliders.Add(hitBoxes[i]);
            }
        }

        return colliders.ToArray();
    }

    private void UpdateHitBoxes(Collider[] hitBoxes)
    {
        //delete all sprites for which the collider is no longer found
        foreach (KeyValuePair<Collider, GameObject> entry in visualizers)
        {
            if (!Array.Exists<Collider>(hitBoxes, e => e == entry.Key))
            {
                visualizers.Remove(entry.Key);
            }
            else if (Array.Exists<Collider>(hitBoxes, e => e == entry.Key))
            {
                UpdateHitBoxFill(entry.Key);
            }
        }     

        //check if there are new colliders
        for (int i = 0; i < hitBoxes.Length; i++)
        {
            if (!visualizers.ContainsKey(hitBoxes[i]))
                SpawnHitBoxes(hitBoxes[i]);
        }
    }

    //check the type of a new collider, instantiate a sprite and add them to the dictionary
    private void SpawnHitBoxes(Collider hitBox)
    {
        if (hitBox is BoxCollider)
        {
            BoxCollider box = hitBox as BoxCollider;
            GameObject visualizer = Instantiate(RectangleSprite, box.center, Quaternion.Euler(-90, 0, 0), worldCanvas.transform);
            visualizer.transform.localScale = new Vector3(box.size.x, box.size.z, 1);

            visualizers.Add(hitBox, visualizer);
        }
        else if (hitBox is SphereCollider)
        {
            SphereCollider sphere = hitBox as SphereCollider;
            GameObject visualizer = Instantiate(CircleSprite, sphere.center, Quaternion.Euler(-90, 0, 0), worldCanvas.transform);
            visualizer.transform.localScale = new Vector3(sphere.radius, 1, sphere.radius);
            visualizers.Add(hitBox, visualizer);
        }
    }

    // update the fill amount of the visualizing image to show attack completion
    private void UpdateHitBoxFill(Collider hitBox)
    {
        if (visualizers[hitBox].GetComponent<Image>())
        {
            if (hitBox is BoxCollider)
            {
                BoxCollider box = hitBox as BoxCollider;
                visualizers[hitBox].GetComponent<Image>().fillAmount = box.center.y;
            }
            else if (hitBox is SphereCollider)
            {
                SphereCollider sphere = hitBox as SphereCollider;
                visualizers[hitBox].GetComponent<Image>().fillAmount = sphere.center.y;
            }               
        }
        else
            Debug.LogError("Instantiated hit box visualizer doesnt contain an Image");       
    }
}
