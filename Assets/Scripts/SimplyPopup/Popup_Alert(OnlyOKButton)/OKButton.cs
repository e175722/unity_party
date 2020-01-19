using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OKButton : MonoBehaviour
{

  public float timeOut = 0.1f;
  private float timeElapsed;
  // Start is called before the first frame update
  void Awake(){
    this.GetComponent<Image>().color = new Color (0, 0, 0, 0);
    this.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color (0, 0, 0, 0);
  }
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    timeElapsed += Time.deltaTime;

    if(timeElapsed >= timeOut) {
      this.gameObject.GetComponent<Image>().color = Color.white;
      this.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
    }


  }
}
