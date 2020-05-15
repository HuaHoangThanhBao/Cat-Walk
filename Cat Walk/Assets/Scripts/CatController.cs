using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CatController : MonoBehaviour {

    public enum State
    {
        Idle,
        StepOne,
        StepTwo,
        StepThree,
        FallTowardStepTwo,
        FallTowardStepThree,
        FallTowardStepOne,
        FallBackStepTwo,
        FallBackStepThree,
    }

    Animator anim;
    Rigidbody2D rb;

    public LayerMask mask; //Background

    FallBackChecking f_B;
    FallTowardChecking f_T;
    GroundedCheck groundCheck;
    
    public State state;
    public Variables variables;

    int temp = 0;

    private void Awake()
    {
        f_B = FindObjectOfType<FallBackChecking>();
        f_T = FindObjectOfType<FallTowardChecking>();
        groundCheck = FindObjectOfType<GroundedCheck>();
    }


    private void GetKeyType()
    {
        variables.mouseButtonDown = Input.GetMouseButtonDown(0);
    }

    private void HandleAnimation()
    {
        if (variables.mouseButtonDown)
        {
            switch (state)
            {
                case State.StepOne:

                    if (!variables.falling_B && !variables.falling_T) Movement();

                    anim.SetBool(variables.stepOne, true);
                    anim.SetBool(variables.stepTwo, false);
                    anim.SetBool(variables.stepThree, false);
                    break;

                case State.StepTwo:

                    if (!variables.falling_B && !variables.falling_T) Movement();

                    anim.SetBool(variables.stepTwo, true);
                    anim.SetBool(variables.stepOne, false);
                    anim.SetBool(variables.stepThree, false);
                    break;

                case State.StepThree:

                    if (!variables.falling_B && !variables.falling_T) Movement();

                    anim.SetBool(variables.stepThree, true);
                    anim.SetBool(variables.stepTwo, false);
                    anim.SetBool(variables.stepOne, false);
                    break;
            }
        }

        if(variables.falling_B || variables.hitGround_T)
        {
            variables.playing = false;

            switch(state)
            {
                case State.FallBackStepTwo:

                    anim.SetBool(variables.fallBackStepTwo, true);
                    anim.SetBool(variables.stepTwo, false);

                    SetSizeWhenDeath();

                    break;

                case State.FallBackStepThree:

                    anim.SetBool(variables.fallBackStepThree, true);
                    anim.SetBool(variables.stepThree, false);

                    SetSizeWhenDeath();

                    break;
            }
        }

        if(variables.falling_T || variables.hitGround_T)
        {
            variables.playing = false;

            switch (state)
            {
                case State.FallTowardStepOne:
                    anim.SetBool(variables.fallTowardStepOne, true);
                    anim.SetBool(variables.stepOne, false);

                    SetSizeWhenDeath();

                    break;

                case State.FallTowardStepTwo:

                    anim.SetBool(variables.fallTowardStepTwo, true);
                    anim.SetBool(variables.stepTwo, false);

                    SetSizeWhenDeath();

                    break;

                case State.FallTowardStepThree:

                    anim.SetBool(variables.fallTowardStepThree, true);
                    anim.SetBool(variables.stepThree, false);

                    SetSizeWhenDeath();

                    break;
            }
        }
    }

    private void SetSizeWhenDeath()
    {
        if ((variables.hitEdge_B && variables.hitGround_B) || (variables.hitEdge_T && variables.hitGround_T))
        {
            this.GetComponent<CapsuleCollider2D>().size = new Vector2(1.9f, 5.15f);
        }

        if ((!variables.hitEdge_B && variables.hitGround_B) || (!variables.hitEdge_T && variables.hitGround_T))
            this.GetComponent<CapsuleCollider2D>().size = new Vector2(1, 5);
    }

    private float startTime = 0;

    private void HandleAudioSource()
    {
        if (variables.playing)
        {
            startTime += 0.1f;

            if(startTime >= 50 && startTime <= 60)
            {
                PlayingAudio();
                
            }
            else if (startTime > 60) startTime = 0;
        }
    }

    public void PlayingAudio()
    {
        FindObjectOfType<AudioManager>().Play("Meow");
    }

    private void Movement()
    {
        if (!variables.falling_B && !variables.falling_T)
        {
            rb.velocity = Vector2.right * variables.speed;

            this.transform.Rotate(new Vector3(0, 0, 5f) * Time.fixedUnscaledDeltaTime * variables.speedRotation);
        }
    }

    void HandleFalling()
    {
        if (variables.falling_B)
        {
            rb.drag = variables.rigiValue;
            rb.gravityScale = variables.rigiValue;
            rb.mass = variables.rigiValue;
        }
        else if (variables.falling_T)
        {
            rb.drag = variables.rigiValue;
            rb.gravityScale = variables.rigiValue;
            rb.mass = variables.rigiValue;
        }

        if(variables.onAir)
        {
            rb.drag = variables.rigiValue;
            rb.gravityScale = variables.rigiValue;
            rb.mass = variables.rigiValue;
        }
    }

    private void HandleState()
    {
        if (variables.mouseButtonDown && !variables.falling_B && !variables.falling_T)
        {
            temp++;
            if (temp == 1) state = State.StepOne;
            if (temp == 2) state = State.StepTwo;
            if (temp == 3)
            {
                state = State.StepThree;
                temp = 1;
            }
        }

        if (variables.hitGround_B)
        {
            switch(state)
            {
                case State.StepTwo:
                    state = State.FallBackStepTwo;
                    break;
                case State.StepThree:
                    state = State.FallBackStepThree;
                    break;
            }
        }

        if(variables.hitGround_T)
        {
            switch (state)
            {
                case State.StepOne:
                    state = State.FallTowardStepOne;
                    break;
                case State.StepTwo:
                    state = State.FallTowardStepTwo;
                    break;
                case State.StepThree:
                    state = State.FallTowardStepThree;
                    break;
            }
        }
    }

    void RayForTrigger()
    {
        //Debug.DrawRay(transform.position, Vector2.right * variables.rayDistance, Color.red, 1);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, variables.rayDistance, mask);

        if(hit.collider != null)
        {
            if (hit.transform.tag == "Background")
            {
                variables.onTriggerBackground = true;
            }
        }
        else variables.onTriggerBackground = false;
    }

	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}

    void Update () {
        if (variables.gameBegin)
        {
            variables.playing = true;

            if (!variables.falling_B && !variables.falling_T)
            {
                GetKeyType();

                RayForTrigger();
            }

            HandleState();
            HandleAnimation();
            HandleAudioSource();
            HandleFalling();
        }
	}
}
