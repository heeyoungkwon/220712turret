using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject playerObject;
    public Transform player;
    public bool canTurretAttack = false;
    public float scriptOutput = 0.0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canTurretAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canTurretAttack = false;
        }
    }
    private void TurretAttack()
    {
        this.transform.LookAt(playerObject.transform);

        if(scriptOutput >= 0.5f)
        {
            scriptOutput = 0.0f;
            GameObject bullet = Instantiate(BulletPrefab, transform);
            bullet.transform.LookAt(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scriptOutput += Time.deltaTime;
        if(canTurretAttack)
        {
            TurretAttack();
        }
        else
        {
            this.transform.Rotate(0, 0.5f, 0);
        }
        
    }
}
