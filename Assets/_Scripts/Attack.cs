using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canAttack = false;

    private void Start()
    {
        _canAttack= true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null)
        {
            _canAttack = false;
            hit.Damage();
        }
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.5f);
        _canAttack = true;
    }
}
