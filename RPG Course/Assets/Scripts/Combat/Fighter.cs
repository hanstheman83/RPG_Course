using UnityEngine;
using RPG.Movement;
using RPG.Core;
//using System.Collections;

namespace RPG.Combat
{

    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        Transform tTarget;

        private void Update()
        {
            if(tTarget == null) { return; }

            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(tTarget.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
            }
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
