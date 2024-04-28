using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BlockingPlayer : MonoBehaviour
{
    public GameObject bowlGameObject;
    public Transform equipTransform;
    public float equipOffset = 1f;
    public bool equipping = false;

    void Start()
    {
         bowlGameObject = GameObject.Find("Bowl");
         equipTransform = GameObject.Find("mixamorig:RightHand").transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (IsPlayerNearBowl() && !equipping)
            {
                EquipBowl();
            }
        }
    }

    bool IsPlayerNearBowl()
    {
        float distance = Vector3.Distance(transform.position, bowlGameObject.transform.position);
        return distance <= equipOffset;
    }

    void EquipBowl()
    {
        bowlGameObject.transform.parent = equipTransform;
        bowlGameObject.transform.localPosition = Vector3.zero;
        bowlGameObject.transform.localRotation = Quaternion.identity;
        equipping = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start") && equipping)
        {
            SceneManager.LoadScene("WinEndingScene");
        }
    }

    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Start") && equipping)
    {
        SceneManager.LoadScene("WinEndingScene");
    }
}
}