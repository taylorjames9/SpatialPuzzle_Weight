using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MySwitcherRule {None=0, SelfChanger=1, OppositeAll=2, OppositeLast=3}

abstract public class AbstractPlatform : MonoBehaviour
{

  public Color offColor;
  public Color onColor;

  private bool unlocked;
  public bool Unlocked{ 
    get { 
      return unlocked; 
    } 
    set
    {
      unlocked = value;
      UpdateMyColor(unlocked);
    }
  }
  public MySwitcherRule myRule;

  public void Start(){
    GetComponent<Renderer>().material.color = offColor;
  }

  public void OnCollisionEnter(Collision collision)
  {

    if (collision.gameObject.GetComponent<Character>())
    {
      ApplyRule();
      Character.Instance.myLastPlatformHit = gameObject;
      Debug.Log("ENTERED" + gameObject.name);
    }
  }

  public void OnCollisionExit(Collision collision)
  {
    if (collision.gameObject.GetComponent<Character>())
      Debug.Log("EXITED" + gameObject.name);
  }


  public void ApplyRule(){ 
    switch((int)myRule){
      case 1:
        Unlocked = !unlocked;
        break;
      case 2:
        foreach(GameObject go in GameManagr.Instance.allPlatforms){
          go.GetComponent<PlatformIndividual>().Unlocked = !unlocked;
        }
        break;
      case 3:
        if (Character.Instance.myLastPlatformHit)
          Unlocked = !Character.Instance.myLastPlatformHit.GetComponent<PlatformIndividual>().unlocked;
        else
          Unlocked = !unlocked;
        break;
      default:
        Debug.Log("NO VALID OPTION");
        break;
    }
    GameManagr.Instance.CheckForSuccess();
  }

  public void UpdateMyColor(bool lockStatus){
    if(lockStatus)
      GetComponent<Renderer>().material.color = onColor;
    else
      GetComponent<Renderer>().material.color = offColor;
  }

}
