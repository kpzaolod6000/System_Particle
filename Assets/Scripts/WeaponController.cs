using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon weapon;
    public string muroTag;

    private bool fire;
    // Start is called before the first frame update
    void Start()
    {
        weapon.muroTag = muroTag;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            fire = false;
        }
        if (fire)
        {
            weapon.Fire();
        }
    }
}
