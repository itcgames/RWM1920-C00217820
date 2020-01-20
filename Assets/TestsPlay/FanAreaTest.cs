using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    
    public class FanAreaTest
    {
        private GameObject Object;
        private FanArea fanarea;


        [SetUp]
        public void Setup()
        {
            Object = GameObject.Instantiate(new GameObject());
            fanarea = Object.AddComponent<FanArea>();
         
        }
        [UnityTest]
        public IEnumerator cubeMoveTest()
        {
            yield return new WaitForSeconds(0.1f);

            Assert.NotNull(fanarea.direction);

        }

    }
}
