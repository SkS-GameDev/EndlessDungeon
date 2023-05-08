using System;
using UnityEngine;

namespace Units.Enemy.State_Machines.State
{
    public class Attack : IState
    {
        #region Variables

        public bool EndAttack;

        private readonly Animator _animator;
        private readonly Enemy _enemy;
        private readonly static int ATTACK1 = Animator.StringToHash("Attack1");
        private Action<string> _animationTriggerName;

        private Func<float> _damage;

        #endregion

        #region Constructors

        public Attack(Enemy enemy, Animator animator)
        {
            _enemy = enemy;
            _animator = animator;
        }

        #endregion

        #region Methods

        public void OnEnter()
        {
            _animator.SetBool(ATTACK1, true);
            _enemy.AnimationTriggerName = HandlerAnimationTrigger;
            EndAttack = false;
        }

        public void Tick()
        {
        }

        public void OnExit()
        {
            _animator.SetBool(ATTACK1, false);
            _enemy.AnimationTriggerName -= HandlerAnimationTrigger;
        }

        #endregion

        #region Methods Other

        private void HandlerAnimationTrigger(string animationTriggerName)
        {
            switch (animationTriggerName)
            {
                case "attack":
                    Debug.Log("attack");
                    break;
                case "attackEnd":
                    Debug.Log("attackEnd");
                    break;
                case "animationEnd":
                    EndAttack = true;
                    break;
            }
        }

        #endregion
    }
}