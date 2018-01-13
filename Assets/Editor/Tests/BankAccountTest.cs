using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace uCapitalSystem
{
    public class BankAccountTest
    {
        [Test]
        public void _0_Add_To_Balance()
        {
            var bankAccount = new GameObject("bankaccount").AddComponent<BankAccount>();
            float amount = 10;
            bankAccount.Add(amount);
            Assert.AreEqual(bankAccount.Balance, amount);
        }

        [Test]
        public void _1_Add_To_Balance_Raise_Event()
        {
            var bankAccount = new GameObject("bankaccount").AddComponent<BankAccount>();
            bool eventRaised = false;
            float amount = 10;
            bankAccount.OnBalanceChanged += (float amt, float balance) => { eventRaised = true; };
            bankAccount.Add(amount);

            Assert.AreEqual(eventRaised, true);
        }

        [Test]
        public void _2_Deduct_From_Balance()
        {
            var bankAccount = new GameObject("bankaccount").AddComponent<BankAccount>();
            float amount = 10;
            bankAccount.Add(amount);
            bankAccount.Deduct(amount);
            Assert.AreEqual(bankAccount.Balance, 0);
        }

        [Test]
        public void _3_Deduct_From_Balance_Raise_Event()
        {
            var bankAccount = new GameObject("bankaccount").AddComponent<BankAccount>();
            bool eventRaised = false;
            float amount = 10;
            bankAccount.Add(amount);
            bankAccount.OnBalanceChanged += (float amt, float balance) => { eventRaised = true; };
            bankAccount.Deduct(amount);

            Assert.AreEqual(eventRaised, true);
        }
    }
}