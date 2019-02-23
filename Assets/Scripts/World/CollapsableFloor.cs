using UnityEngine;

public class CollapsableFloor : MonoBehaviour 
{
    public Transform top;
    public Transform bot;
    public float threshold;
    public bool set = true;

    Vector3 topReset;
    enum State { Top, Mid, Bot }
    State state = State.Top;

    void Start()
    {
        topReset = top.position;
    }

    public void Collapse()
    {
        if (!set)
        {
            Reset();
            return;
        }
        ChangeState(State.Mid);
    }

    public void Reset()
    {
        ChangeState(State.Top);
    }

    void ChangeState(State newState)
    {
        state = newState;
        switch (newState)
        {
            case State.Top:
                set = true;
                top.position = topReset;
                top.gameObject.SetActive(true);
                bot.gameObject.SetActive(false);
                top.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                break;
            case State.Mid:
                top.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                set = false;
                break;
            case State.Bot:
                top.gameObject.SetActive(false);
                bot.gameObject.SetActive(true);
                break;
        }
    }

    void Update()
    {
        if (state == State.Mid && top.position.y <= bot.position.y + threshold)
        {
            ChangeState(State.Bot);
        }
    }
}