using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace uCapitalSystem
{
    public class TransactionTest
    {

        [Test]
        public void _0_Transaction_Init_With_Correct_Values()
        {
            float amount = 10;
            var seller = new GameObject();
            var buyer = new GameObject();

            var transaction = ScriptableObject.CreateInstance<Transaction>();
            transaction.Init(buyer, seller, amount);
            Assert.AreEqual(transaction.Amount, amount);
            Assert.AreEqual(transaction.Seller, seller);
            Assert.AreEqual(transaction.Buyer, buyer);
        }
    }
}