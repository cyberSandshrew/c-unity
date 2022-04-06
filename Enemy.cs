using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    public int curHp;// curent hit points

    public int maxHp;  //max hit points

    public int goldToGive;  //goldgiven

    public Image healthBarFill; //fill

    public void Damage()
    {
        //Subtract 1 from curHP
        curHp--;
        //Update health bar
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

        //if (curHp <= 0)
       // {
           // Defeated();
        //}
    }
}
