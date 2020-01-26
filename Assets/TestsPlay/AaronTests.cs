using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class AaronTests : MonoBehaviour
    {

        GameObject fan;
        GameObject cube;
        GameObject ground;

        [SetUp]
        public void SetUp()
        {
            fan = Instantiate(Resources.Load<GameObject>("Fan"));
            cube = Instantiate(Resources.Load<GameObject>("cube"));
            ground = Instantiate(Resources.Load<GameObject>("Ground"));

        }

        [TearDown]
        public void TearDown()
        {
            Destroy(fan);
            Destroy(ground);
            Destroy(cube);
        }

        [UnityTest]
        public IEnumerator FanPushingObjectbasic()
        {
            fan.transform.position = new Vector2(0,0);
            cube.transform.position = new Vector2(2, 0);
            ground.transform.position = new Vector2(.4f, -1.67f);

            Vector2 m_startingCoords = cube.transform.position;

            yield return new WaitForSeconds(1f);

            Vector2 m_EndCoords = cube.transform.position;
            Assert.AreNotEqual(m_startingCoords, m_EndCoords);
        }

        [UnityTest]
        public IEnumerator ObjectStopsOutofFanArea()
        {

            fan.transform.position = new Vector2(0, 0);
            cube.transform.position = new Vector2(2, 0);
            ground.transform.position = new Vector2(.4f, -1.67f);

            Vector2 m_SpawnCoords = cube.transform.position;
            yield return new WaitForSeconds(1f);
            Vector2 m_MidCoords = cube.transform.position;
            Assert.AreNotEqual(m_SpawnCoords, m_MidCoords);

            yield return new WaitForSeconds(3f);
            Vector2 m_EndCordsOne = cube.transform.position;
            yield return new WaitForSeconds(1f);
            Vector2 m_EndCordstwo = cube.transform.position;
            Assert.AreEqual(m_EndCordsOne, m_EndCordstwo);
        }

        [UnityTest]
        public IEnumerator FanRangeTest()
        {


            fan.transform.position = new Vector2(0, 0);
            cube.transform.position = new Vector2(2, 0);
            ground.transform.position = new Vector2(.4f, -1.67f);


            Vector2 m_SpawnCoords = cube.transform.position;
            yield return new WaitForSeconds(1f);
            Vector2 m_MidCoords = cube.transform.position;
            Assert.AreNotEqual(m_SpawnCoords, m_MidCoords);


            yield return new WaitForSeconds(3f);


            cube.GetComponent<Rigidbody2D>().mass = 10;
            cube.transform.position = new Vector2(2, 0);

            Vector2 m_SpawnCoordsTwo = cube.transform.position;
            yield return new WaitForSeconds(1f);
            Vector2 m_MidCoordsTwo = cube.transform.position;

            Assert.AreEqual(m_SpawnCoordsTwo, m_SpawnCoords);
            Assert.AreNotEqual(m_MidCoords, m_MidCoordsTwo);
        }

        [UnityTest]
        public IEnumerator FanRotation()
        {

            GameObject fanblade = Instantiate(Resources.Load<GameObject>("FanBlade"));

            fanblade.GetComponent<RotateFanBlade>().rotationSpeed = 10;

            Quaternion rotationStart = fanblade.transform.rotation;
            yield return new WaitForSeconds(1f);
            Quaternion rotationEnd = fanblade.transform.rotation;
            Assert.AreNotEqual(rotationStart, rotationEnd);

            fanblade.GetComponent<RotateFanBlade>().rotationSpeed = 25;


            Quaternion rotationStartTwo = fanblade.transform.rotation;
            yield return new WaitForSeconds(1f);
            Quaternion rotationEndTwo = fanblade.transform.rotation;
            Assert.AreNotEqual(rotationStartTwo, rotationEndTwo);

            Assert.AreNotEqual(rotationStart, rotationStartTwo);
            Assert.AreNotEqual(rotationEnd, rotationEndTwo);
        }

        [UnityTest]
        public IEnumerator SoundPlaying()
        {
            GameObject AirFlow = Instantiate(Resources.Load<GameObject>("AirFlow"));
            yield return new WaitForSeconds(.2f);
            Assert.IsTrue( AirFlow.GetComponent<AudioSource>().isActiveAndEnabled);
        }

        [UnityTest]
        public IEnumerator MultiObject()
        {

            GameObject cubeTwo = Instantiate(Resources.Load<GameObject>("cube"));
            GameObject cubeThree = Instantiate(Resources.Load<GameObject>("cube"));

            fan.transform.position = new Vector2(0, 0);
            ground.transform.position = new Vector2(.4f, -1.67f);

            cube.GetComponent<Rigidbody2D>().mass = 10;
            cubeTwo.GetComponent<Rigidbody2D>().mass = 5;
            cubeThree.GetComponent<Rigidbody2D>().mass = 1;


            cube.transform.position = new Vector2(2, 0);
            cubeTwo.transform.position = new Vector2(2, 1);
            cubeThree.transform.position = new Vector2(2,2);

            yield return new WaitForSeconds(2f);
            Vector2 m_startingCoords = cube.transform.position;
            Vector2 m_startingCoordsTwo = cubeTwo.transform.position;
            Vector2 m_startingCoordsThree = cubeThree.transform.position;

            yield return new WaitForSeconds(2f);
            Vector2 m_EndCoords = cube.transform.position;
            Vector2 m_EndCoordsTwo = cubeTwo.transform.position;
            Vector2 m_EndCoordsThree = cubeThree.transform.position;

            Assert.AreNotEqual(m_startingCoords, m_EndCoords);
            Assert.AreNotEqual(m_startingCoords, m_EndCoordsTwo);
            Assert.AreNotEqual(m_startingCoords, m_EndCoordsThree);

            Assert.AreNotEqual(m_startingCoordsTwo, m_EndCoords);
            Assert.AreNotEqual(m_startingCoordsTwo, m_EndCoordsTwo);
            Assert.AreNotEqual(m_startingCoordsTwo, m_EndCoordsThree);

            Assert.AreNotEqual(m_startingCoordsThree, m_EndCoords);
            Assert.AreNotEqual(m_startingCoordsThree, m_EndCoordsTwo);
            Assert.AreNotEqual(m_startingCoordsThree, m_EndCoordsThree);



            yield return new WaitForSeconds(5f);



            cube.GetComponent<Rigidbody2D>().mass = 10;
            cubeTwo.GetComponent<Rigidbody2D>().mass = 2;
            cubeThree.GetComponent<Rigidbody2D>().mass = .1f;

            cube.transform.position = new Vector2(2, 0);
            cubeTwo.transform.position = new Vector2(2, 1);
            cubeThree.transform.position = new Vector2(2, 2);

            yield return new WaitForSeconds(2f);
            Vector2 m_oneStartingCoords = cube.transform.position;
            Vector2 m_oneStartingCoordsTwo = cubeTwo.transform.position;
            Vector2 m_oneStartingCoordsThree = cubeThree.transform.position;

            yield return new WaitForSeconds(2f);
            Vector2 m_oneEndCoords = cube.transform.position;
            Vector2 m_oneEndCoordsTwo = cubeTwo.transform.position;
            Vector2 m_oneEndCoordsThree = cubeThree.transform.position;



            Assert.AreNotEqual(m_startingCoords, m_oneStartingCoords);
            Assert.AreNotEqual(m_startingCoordsTwo, m_oneStartingCoordsTwo);
            Assert.AreNotEqual(m_startingCoordsThree, m_oneStartingCoordsThree);

            Assert.AreNotEqual(m_EndCoords, m_oneEndCoords);
            Assert.AreNotEqual(m_EndCoordsTwo, m_oneEndCoordsTwo);
            Assert.AreNotEqual(m_EndCoordsThree, m_oneEndCoordsThree);

        }
    }
}
