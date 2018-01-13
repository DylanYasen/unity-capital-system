using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uCapitalSystem
{
    public class CapitalManager : ScriptableObject
    {
        public delegate void TransactionProcessedDelegate(Transaction transaction);
        public event TransactionProcessedDelegate OnTransactionFailed = delegate { };
        public event TransactionProcessedDelegate OnTransactionSucceed = delegate { };

        public bool ProcessTransaction(Transaction transaction)
        {
            BankAccount sellerAccount = transaction.Seller.GetComponent<BankAccount>();
            BankAccount buyerAccount = transaction.Buyer.GetComponent<BankAccount>();
            if (buyerAccount != null)
            {
                bool hasEnoughCapital = buyerAccount.Deduct(transaction.Amount);
                if (!hasEnoughCapital)
                {
                    OnTransactionFailed(transaction);
                    return false;
                }
            }
            if (sellerAccount != null)
            {
                sellerAccount.Add(transaction.Amount);
            }

            OnTransactionSucceed(transaction);
            return true;
        }
    }
}
