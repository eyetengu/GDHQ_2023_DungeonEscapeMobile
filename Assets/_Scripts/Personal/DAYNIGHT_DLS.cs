using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAYNIGHT_DLS : MonoBehaviour
{
    //this is code that was inspired by the idea to make a day/week/month/year cycle and see how to do it.

    enum Months { January, February, March, May, June, July, August, September, October, November, December}

    public int day = 1;
    public int week = 1;
    public int month = 1;
    public int year = 1;
    public int season = 1;

    public float waitTime = 3;
    public bool _isItANewDay = false;
    public string currentMonth;


    // Start is called before the first frame update
    void Start()
    {
        _isItANewDay =true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isItANewDay)
        { StartCoroutine(DailySlog()); }

        //month = Months(month);

        Debug.Log(day +"/"+ week+"/"+ currentMonth +"/"+year);
    }

    IEnumerator DailySlog()
    {
        _isItANewDay = false;
        yield return new WaitForSeconds(waitTime);

        day++;
        if (day % 7 == 0)
        {
            week++;
        }
        if (day > 28) day = 1;

        if (week > 4)
        {
            week = 1;
            month++;
        }


        if (month > 12)
        {
            month = 1;
            year++;
        }        

        _isItANewDay=true;
    }

}
