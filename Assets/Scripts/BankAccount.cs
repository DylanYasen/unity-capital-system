using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uCapitalSystem 
{
    public class BankAccount : MonoBehaviour 
    {
        public delegate void BalanceChangedDelegate (float changedAmount, float currentBalance);
        public event BalanceChangedDelegate OnBalanceChanged = delegate { };

        public float Balance { get; private set; }

        public bool Deduct (float amount) {
            if (Balance >= amount) {
                Balance -= amount;
                OnBalanceChanged (amount, Balance);
                return true;
            }

            return false;
        }

        public float Add (float amount) {
            Balance += amount;
            OnBalanceChanged (amount, Balance);
            return Balance;
        }
    }
}