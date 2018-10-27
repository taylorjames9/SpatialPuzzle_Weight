using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

  public static Character Instance;
  public GameObject myLastPlatformHit;

  void OnEnable(){
    Instance = this;
  }
}
