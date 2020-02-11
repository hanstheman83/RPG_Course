using UnityEngine;
using RPG.Movement;
using RPG.Core;
//using System.Collections;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 5f;
        Transform tTarget;
        float timeSinceLastAttack = 0f;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if(tTarget == null) { return; }

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(tTarget.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack"); // will trigger Hit() event
                timeSinceLastAttack = 0f;
            }
        }
        void Hit() // Animation Event, doesn't show references..
        {
            Health healthComponent = tTarget.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, tTarget.position) < weaponRange;
        }
        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            tTarget = combatTarget.transform;
            print("Take that you short, squat peasant!");
        }
        public void Cancel()
        {
            tTarget = null;
        }
     



    }

}
