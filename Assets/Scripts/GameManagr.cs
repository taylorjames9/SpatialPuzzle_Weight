using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagr : MonoBehaviour {

  //Responsibilities: this script keeps track of how many platforms have turned green
  //Every time a platform turns green, this script checks if all 3 platforms are green,
  //and if so fires an event that says all three platforms are green

  public static GameManagr Instance;

  void OnEnable(){
    Instance = this;
  }

  public List<GameObject> allPlatforms;

  public List<Color> colorChart;

  public bool CheckForSuccess(){
    foreach(GameObject go in allPlatforms){
      if(!go.GetComponent<Platform>().Unlocked){
        return false;
      }
    }
    GateManager.Instance.OpenGate();
    return true;
  }

  public bool CheckForFailure(){
    foreach (GameObject go in allPlatforms)
    {
      if (go.GetComponent<Platform>().Unlocked){
        return false;
      }
    }
    GateManager.Instance.CloseGate();
    return true;
  }


}
