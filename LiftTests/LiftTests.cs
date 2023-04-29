using Lift;
using NUnit.Framework;

namespace LiftTests
{
    public class LiftTests
    {
        [Test]
        public void Test_ValidInput_PeoplesFitOnTheLift()
        {
            var peopleCount = 15;
            var inputLiftState = new int[] { 0, 0, 0, 0 };
            LiftSimulator liftSimulator = new LiftSimulator();

            var result = liftSimulator.FitPeopleOnTheLift(peopleCount, inputLiftState);

            Assert.That(result[0], Is.EqualTo(4));
            Assert.That(result[1], Is.EqualTo(4));
            Assert.That(result[2], Is.EqualTo(4));
            Assert.That(result[3], Is.EqualTo(3));
        }

        [Test]
        public void Test_InvalidPeopleCount_ThrowsException()
        {
            var peopleCount = -1;
            var inputLiftState = new int[] { 0, 0, 0, 3 };
            LiftSimulator liftSimulator = new LiftSimulator();
                        
            Assert.That(() => liftSimulator.FitPeopleOnTheLift(peopleCount, inputLiftState), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_InvalidLiftSize_ThrowsException()
        {
            var peopleCount = 10;
            var invalidSeatsNumber = 5;
            var inputLiftState = new int[] { 0, invalidSeatsNumber, 0 };
            LiftSimulator liftSimulator = new LiftSimulator();

            Assert.That(() => liftSimulator.FitPeopleOnTheLift(peopleCount, inputLiftState), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_InvalidLiftState_ThrowsException()
        {
            var peopleCount = 10;
            int[] inputLiftState = null;
            LiftSimulator liftSimulator = new LiftSimulator();

            Assert.That(() => liftSimulator.FitPeopleOnTheLift(peopleCount, inputLiftState), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_NotEnoughSpaceOnTheLift_CorrectMessage()
        {
            var peopleCount = 15;
            var inputLiftState = new int[] { 0, 4, 0 };
            LiftSimulator liftSimulator = new LiftSimulator();


            var result = liftSimulator.FitPeopleOnTheLiftAndGetResult(peopleCount, inputLiftState);

            Assert.That(result, Is.EqualTo("There isn't enough space! 7 people in a queue!\r\n4 4 4"));
        }

        [Test]
        public void Test_EmptySpaces()
        { 
            var peopleCount = 13;
            var inputLiftState = new int[] { 0, 1, 0, 0 };
            LiftSimulator liftSimulator = new LiftSimulator();


            var result = liftSimulator.FitPeopleOnTheLiftAndGetResult(peopleCount, inputLiftState);

            Assert.That(result, Is.EqualTo("The lift has 2 empty spots!\r\n4 4 4 2"));
        }

        [Test]
        public void Test_FullLift()
        {
            var peopleCount = 16;
            var inputLiftState = new int[] { 0, 0, 0, 0 };
            LiftSimulator liftSimulator = new LiftSimulator();


            var result = liftSimulator.FitPeopleOnTheLiftAndGetResult(peopleCount, inputLiftState);

            Assert.That(result, Is.EqualTo("All people placed and the lift if full.\r\n4 4 4 4"));
        }

    }
}