using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

  public static Character Instance;
  public GameObject myLastPlatformHit;
  public bool myLastPlatformHitCanBeSet;

  void OnEnable(){
    Instance = this;
    myLastPlatformHitCanBeSet = true;
  }
}
