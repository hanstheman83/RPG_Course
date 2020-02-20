using UnityEngine;
//using System.Collections;

    namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;

        bool bIsDead = false;

        public bool IsDead()
        {
            return bIsDead;
        }
        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print("health: " + healthPoints);
            if(healthPoints == 0)
            {
                Die();
            }
        }
        private void Die()
        {
            if(bIsDead) { return; }
            else
            {
                GetComponent<Animator>().SetTrigger("die");
                bIsDead = true;
                GetComponent<ActionScheduler>().CancelCurrentAction();
            }
        }

    }
}