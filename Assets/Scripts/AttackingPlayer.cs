using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackPlayer : MonoBehaviour
{
    public GameObject hammerGameObject;
    public Transform equipTransform;
    public float equipOffset = 1f;
    public bool equipping = false;

    void Start()
    {
         hammerGameObject = GameObject.Find("Hammer");
         equipTransform = GameObject.Find("mixamorig:RightHand").transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (IsPlayerNearHammer() && !equipping)
            {
                EquipHammer();
            }
        }
    }

    bool IsPlayerNearHammer()
    {
        float distance = Vector3.Distance(transform.position, hammerGameObject.transform.position);
        return distance <= equipOffset;
    }

    void EquipHammer()
    {
        hammerGameObject.transform.parent = equipTransform;
        hammerGameObject.transform.localPosition = Vector3.zero;
        hammerGameObject.transform.localRotation = Quaternion.identity;
        equipping = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && equipping)
        {
            SceneManager.LoadScene("WinEndingScene");
        }
    }
}
