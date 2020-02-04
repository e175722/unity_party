using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
public AudioClip back;
public AudioClip next;
AudioSource audioSource;
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
            this.gameObject.GetComponent<Image>().color = Color.gray;

            }
    }

    void Start ()
    {
        //this.GetComponent<Image>().color = new Color (0, 0, 0, 0);
        audioSource = GetComponent<AudioSource>();
        open.Setup (gameObject);
        open.scaleEndAsObservable.Subscribe (_ => state = State.Open);
       open.Play ();
       audioSource.PlayOneShot(next);
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
        //audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(next);
        close.Play ();
    }
    public void Close2 ()
    {
        //audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(back);
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
