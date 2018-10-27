using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour {


  //subscribe to an event called platform turned green
  //if the gameManager says that there are 3 green platforms... then open the gate

  public static GateManager Instance;

  void OnEnable(){
    Instance = this;
  }

  public void OpenGate(){
    GetComponent<Animator>().SetTrigger("Open");
    Debug.Log("COUNTING NUMBER OF TIMES OPENING GATE");
  }

  public void CloseGate()
  {
    GetComponent<Animator>().SetTrigger("Close");
    Debug.Log("COUNTING NUMBER OF TIMES CLSOING GATE");

  }


}
