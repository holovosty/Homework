using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(WayPointMovement))]

public class MonsterAnimatorController : MonoBehaviour
{
    private Animator _animator;
    private WayPointMovement _wayPointMovement;

    public static class AnimatorController
    {
        public static class Parametrs
        {
            public const string DirectionX = "directionX";
            public const string DirectionY = "directionY";
        }
    }

    public void Start()
    {
        _wayPointMovement = GetComponent<WayPointMovement>();
        _animator = GetComponent<Animator>();
    }

    public void UpdateAnimatorParameter()
    {
        Vector3 direction = _wayPointMovement.GetDirection();

        if (direction.x != 0 && direction.y != 0)
        {
            _animator.SetFloat(AnimatorController.Parametrs.DirectionX, direction.x);
            _animator.SetFloat(AnimatorController.Parametrs.DirectionY, 0);
        }
        else
        {
            _animator.SetFloat(AnimatorController.Parametrs.DirectionX, direction.x);
            _animator.SetFloat(AnimatorController.Parametrs.DirectionY, direction.y);
        }

    }

    public void Update()
    {
        UpdateAnimatorParameter();
    }
}
