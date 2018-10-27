using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MySwitcherRule { None = 0, SelfChanger = 1, OppositeAll = 2, OppositeLast = 3 }

public class Platform : MonoBehaviour
{
  private bool unlocked;
  public bool Unlocked
  {
    get
    {
      return unlocked;
    }
    set
    {
      unlocked = value;
      UpdateMyColor(unlocked);
    }
  }
  public MySwitcherRule myRule;

  public Light myLight;

  public void Start()
  {
    int r = UnityEngine.Random.Range(0, 2);
    Debug.Log("r = " + r);
    Unlocked = r != 0;
  }

  public void ApplyRule()
  {
    switch ((int)myRule)
    {
      ///self changer
      case 1:
        Unlocked = !unlocked;
        break;
      //opposite all
      case 2:
        foreach (GameObject go in GameManagr.Instance.allPlatforms)
        {
          go.GetComponent<Platform>().Unlocked = !go.GetComponent<Platform>().unlocked;
        }
        break;
      //opposite last
      case 3:
        if (Character.Instance.myLastPlatformHit)
        {
          if(Character.Instance.myLastPlatformHit != gameObject)
            Unlocked = !Character.Instance.myLastPlatformHit.GetComponent<Platform>().unlocked;
        }
        break;
      default:
        Debug.Log("NO VALID OPTION");
        break;
    }
    GameManagr.Instance.CheckForSuccess();
    GameManagr.Instance.CheckForFailure();
  }

  public void UpdateMyColor(bool _unlockd)
  {
    if (_unlockd)
      //GetComponent<Renderer>().material.color = GameManagr.Instance.colorChart[1];
      GetComponent<Renderer>().material = GameManagr.Instance.matChart[1];
    else
      //GetComponent<Renderer>().material.color = GameManagr.Instance.colorChart[0];
      GetComponent<Renderer>().material = GameManagr.Instance.matChart[0];
  }

}
