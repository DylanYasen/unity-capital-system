using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


namespace uCapitalSystem
{
    public class CapitalManagerTest
    {

        [Test]
        public void _0_Process_Valid_Transaction()
        {
            var capitalManager = ScriptableObject.CreateInstance<CapitalManager>();

            float transactionAmount = 20;

            var buyer = new GameObject();
            var buyerAccount = buyer.AddComponent<BankAccount>();
            buyerAccount.Add(transactionAmount * 2);

            var seller = new GameObject();
            var sellerAccount = seller.AddComponent<BankAccount>();

            var transaction = ScriptableObject.CreateInstance<Transaction>();
            transaction.Init(buyer, seller, transactionAmount);

            bool transactionSucceed = capitalManager.ProcessTransaction(transaction);

            Assert.AreEqual(transactionSucceed, true);
        }

        [Test]
        public void _1_Process_Valid_Transaction_Raise_Event()
        {
            var capitalManager = ScriptableObject.CreateInstance<CapitalManager>();

            float transactionAmount = 20;

            var buyer = new GameObject();
            var buyerAccount = buyer.AddComponent<BankAccount>();
            buyerAccount.Add(transactionAmount * 2);

            var seller = new GameObject();
            var sellerAccount = seller.AddComponent<BankAccount>();


            var transaction = ScriptableObject.CreateInstance<Transaction>();
            transaction.Init(buyer, seller, transactionAmount);

            bool eventRaised = false;
            capitalManager.OnTransactionSucceed += (Transaction tran) => { eventRaised = true; };

            capitalManager.ProcessTransaction(transaction);

            Assert.AreEqual(eventRaised, true);
        }


        [Test]
        public void _2_Do_No_Process_Invalid_Transaction()
        {
            var capitalManager = ScriptableObject.CreateInstance<CapitalManager>();

            float transactionAmount = 20;

            var buyer = new GameObject();
            var buyerAccount = buyer.AddComponent<BankAccount>();
            buyerAccount.Add(transactionAmount / 2);

            var seller = new GameObject();
            var sellerAccount = seller.AddComponent<BankAccount>();
            var transaction = ScriptableObject.CreateInstance<Transaction>();
            transaction.Init(buyer, seller, transactionAmount);

            bool transactionSucceed = capitalManager.ProcessTransaction(transaction);

            Assert.AreEqual(transactionSucceed, false);
        }

        [Test]
        public void _3_Do_No_Process_Invalid_Transaction_Raise_Event()
        {
            var capitalManager = ScriptableObject.CreateInstance<CapitalManager>();

            float transactionAmount = 20;

            var buyer = new GameObject();
            var buyerAccount = buyer.AddComponent<BankAccount>();
            buyerAccount.Add(transactionAmount / 2);

            var seller = new GameObject();
            var sellerAccount = seller.AddComponent<BankAccount>();
            var transaction = ScriptableObject.CreateInstance<Transaction>();
            transaction.Init(buyer, seller, transactionAmount);

            bool eventRaised = false;
            capitalManager.OnTransactionFailed += (Transaction tran) => { eventRaised = true; };

            capitalManager.ProcessTransaction(transaction);

            Assert.AreEqual(eventRaised, true);
        }
    }
}