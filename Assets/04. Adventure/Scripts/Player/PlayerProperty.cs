using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public bool bearDie;
    public bool dogDie;
    public bool bearFoodQuest;
    public bool boxKeyGet;
    public bool dogFoodQuest;
    public bool healingFoodQuest;

    private RaycastHit hit;
    void Start()
    {
        bearDie = false;
        dogDie = false;
        bearFoodQuest = false;
        boxKeyGet = false;
        dogFoodQuest = false;
        healingFoodQuest = false;
    }

    void Update()
    {
    }
}
