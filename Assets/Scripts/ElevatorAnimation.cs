using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]

public class ElevatorAnimation : MonoBehaviour
{
    private Animator _animator;

    public static class AnimatorController
    {
        public static class States
        {
            public const string Arrived = "ElevatorArrive";
        }
    }

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetTrigger(AnimatorController.States.Arrived);
    }
}