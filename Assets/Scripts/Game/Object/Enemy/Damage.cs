using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int id;
    public int hitDamage;
    [SerializeField] GameObject CSVreadObject;
    EnemyCSVReader CSVread;

    void Start()
    {
        CSVreadObject = GameObject.Find("EmyCSVRead");
        CSVread = CSVreadObject.GetComponent<EnemyCSVReader>();
        hitDamage = CSVread.atkGetter(id);
        Debug.Log(hitDamage);
    }
}
