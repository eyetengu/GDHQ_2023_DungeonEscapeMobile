using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseClass : MonoBehaviour
{
    //the following fields are protected which means that ONLY this class
    //and all classes that derive from this class may access/modify their values
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;


    private void Start()
    {
        Init(); //kick things off with Init() code
    }

    public virtual void Init()
    {
        //Initialize this class and all deriving classes
    }

    public virtual void Update()    //virtual keyword signifies derived classes may modify it
    {
        //General code HERE for all to draw from 
    }

    public abstract void Damage();  //This method offers NO SOLUTIONS
    //It requires the deriving classes to have this method and, optionally, define it

}
