using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTriggerPlatform : MonoBehaviour {

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.GetComponent<Character>())
    {
      transform.parent.GetComponent<Platform>().ApplyRule();
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.GetComponent<Character>())
    {
      other.gameObject.GetComponent<Character>().myLastPlatformHit = transform.parent.gameObject;
    }
  }
}
