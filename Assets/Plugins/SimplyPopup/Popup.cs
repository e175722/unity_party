using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public enum State
    {
        Open,
        Close,
        UnUsed
    }

    public State state { get; private set; }

    public TweenScale open, close;
    public float timeOut = 0.1f;
    private float timeElapsed;
    
    void Awake(){
        this.GetComponent<Image>().color = new Color (0, 0, 0, 0);
    }
    
    void Update() {
        timeElapsed += Time.deltaTime;

        if(timeElapsed >= timeOut) {
            this.gameObject.GetComponent<Image>().color = Color.red;

            }
    }

    void Start ()
    {
        //this.GetComponent<Image>().color = new Color (0, 0, 0, 0);
        open.Setup (gameObject);
        open.scaleEndAsObservable.Subscribe (_ => state = State.Open);
       open.Play ();
       close.Setup (gameObject);
        close.scaleEndAsObservable.Subscribe (_ => state = State.Open);
        //this.gameObject.GetComponent<Image>().color = Color.red;
    }

    public void Open2 ()
    {
        open.Play ();
        Debug.Log("ssss");
    }

    public void Close ()
    {
        close.Play ();
    }

    public void Toggle ()
    {
        switch (state) {
        case State.UnUsed:
        case State.Close:
            open.Play ();
            break;
        case State.Open:
            //close.Play ();
            break;
        }
    }
}