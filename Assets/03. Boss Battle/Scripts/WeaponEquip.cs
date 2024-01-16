using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquip : MonoBehaviour
{
    private PlayerData plData;

    private void Start()
    {
        plData = FindObjectOfType<PlayerData>();

        if(plData.weaponEquip != null)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GameObject weapon = Instantiate(plData.weaponEquip.model, transform.position, Quaternion.identity, transform);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}
