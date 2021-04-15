using AwesomeApplication.Domain;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AwesomeApplication.Tests
{
    [TestFixture]
    public class PersonTests
    {
        private Person person;

        [SetUp]
        public void Setup()
        {
            person = new Person() { FirstName = "test", LastName = "person" };
        }

        [Test]
        public void AssignTask_WhenCalled_AssignsPersonToTask()
        {
            //arrange
            var task = new AwesomeApplication.Domain.Task()
            {
                Id = 0,
                Descrption = "Test Task"
            };

            //act
            person.AssignTask(task);

            //assert
            //Assert.AreEqual(task.AssignedPerson, person);
            task.AssignedPerson.Should().BeSameAs(person);

        }

        public static IEnumerable<TestCaseData> AssignTask_WhenCalled_ShouldThrowException_TestCases
        {
            get
            {
                yield return new TestCaseData(new Person() { 
                        StartDate = new System.DateTime(2021, 1, 1), 
                        EndDate = new System.DateTime(2021, 1, 2) 
                    }, new Task()
                    {
                        StartDate = new System.DateTime(2020, 1, 30)
                    }
                    ).SetName("PersonStartsAfterTaskEndDate");
                yield return new TestCaseData(new Person()
                {
                    StartDate = new System.DateTime(2021, 1, 1),
                    EndDate = new System.DateTime(2021, 1, 2)
                }, new Task()
                {
                    StartDate = new System.DateTime(2021, 1, 30)
                }
                    ).SetName("PersonFinishedBeforeTaskStartDate");
            }
        }

        [Test]
        [TestCaseSource("AssignTask_WhenCalled_ShouldThrowException_TestCases")]
        public void AssignTask_WhenCalled_ShouldThrowException(Person person, Task task)
        {
            Action act = () => person.AssignTask(task);

            act.Should().Throw<ApplicationException>();
                    
        }
    }
}