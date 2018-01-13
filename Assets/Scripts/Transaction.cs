using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uCapitalSystem
{
    public class Transaction : ScriptableObject
    {
        public GameObject Buyer { get; private set; }
        public GameObject Seller { get; private set; }
        public float Amount { get; private set; }

        public virtual void Init(GameObject buyer, GameObject seller, float amount)
        {
            this.Buyer = buyer;
            this.Seller = seller;
            this.Amount = amount;
        }
    }
}
