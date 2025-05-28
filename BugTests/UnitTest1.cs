using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BugTests
{
    [TestClass]
    public class BugStateTransitionTests
    {
        [TestMethod]
        public void OpenState_WhenAssigned_TransitionsToAssigned()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.GetState());
        }

        [TestMethod]
        public void AssignedState_WhenClosed_TransitionsToClosed()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.GetState());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OpenState_WhenClosed_ThrowsInvalidOperation()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Close();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ClosedState_WhenAssigned_ThrowsInvalidOperation()
        {
            var bug = new Bug(Bug.State.Closed);
            bug.Assign();
        }

        [TestMethod]
        public void ResolvedState_WhenTested_TransitionsToTesting()
        {
            var bug = new Bug(Bug.State.Resolved);
            bug.Test();
            Assert.AreEqual(Bug.State.Testing, bug.GetState());
        }

        [TestMethod]
        public void TestingState_WhenRejected_TransitionsToRejected()
        {
            var bug = new Bug(Bug.State.Testing);
            bug.Reject();
            Assert.AreEqual(Bug.State.Rejected, bug.GetState());
        }

        [TestMethod]
        public void CompleteWorkflow_FromOpenToClosed_SuccessfullyTransitions()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            bug.Resolve();
            bug.Test();
            bug.Verify();
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.GetState());
        }

        [TestMethod]
        public void RejectedState_WhenReopened_TransitionsToReopened()
        {
            var bug = new Bug(Bug.State.Rejected);
            bug.Reopen();
            Assert.AreEqual(Bug.State.Reopened, bug.GetState());
        }

        [TestMethod]
        public void DeferredState_WhenAssigned_TransitionsToAssigned()
        {
            var bug = new Bug(Bug.State.Deferred);
 Check failure on line 80 in BugTests/UnitTest1.cs

GitHub Actions
/ build

'Bug.State' does not contain a definition for 'Deferred'

 Check failure on line 80 in BugTests/UnitTest1.cs

GitHub Actions
/ build

'Bug.State' does not contain a definition for 'Deferred'
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.GetState());
        }

        [TestMethod]
        public void VerifiedState_WhenReopened_TransitionsToReopened()
        {
            var bug = new Bug(Bug.State.Verified);
            bug.Reopen();
            Assert.AreEqual(Bug.State.Reopened, bug.GetState());
        }

        [TestMethod]
        public void ClosedState_WhenReopened_TransitionsToReopened()
        {
            var bug = new Bug(Bug.State.Closed);
            bug.Reopen();
            Assert.AreEqual(Bug.State.Reopened, bug.GetState());
        }

        [TestMethod]
        public void ReopenedState_WhenClosed_TransitionsToClosed()
        {
            var bug = new Bug(Bug.State.Reopened);
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.GetState());
        }

        [TestMethod]
        public void AssignedState_WhenAssignedAgain_RemainsAssigned()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.GetState());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestingState_WhenClosed_ThrowsInvalidOperation()
        {
            var bug = new Bug(Bug.State.Testing);
            bug.Close();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RejectedState_WhenVerified_ThrowsInvalidOperation()
        {
            var bug = new Bug(Bug.State.Rejected);
            bug.Verify();
        }

        [TestMethod]
        public void ComplexWorkflow_WithRejection_SuccessfullyCompletes()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            bug.Resolve();
            bug.Test();
            bug.Reject();
            bug.Assign();
            bug.Resolve();
            bug.Verify();
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.GetState());
        }

        [TestMethod]
        public void NewBug_WithOpenState_HasCorrectInitialState()
        {
            var bug = new Bug(Bug.State.Open);
            Assert.AreEqual(Bug.State.Open, bug.GetState());
        }

        [TestMethod]
        public void NewBug_WithClosedState_HasCorrectInitialState()
        {
            var bug = new Bug(Bug.State.Closed);
            Assert.AreEqual(Bug.State.Closed, bug.GetState());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeferredState_WhenClosed_ThrowsInvalidOperation()
        {
            var bug = new Bug(Bug.State.Deferred);
 Check failure on line 166 in BugTests/UnitTest1.cs

GitHub Actions
/ build

'Bug.State' does not contain a definition for 'Deferred'

 Check failure on line 166 in BugTests/UnitTest1.cs

GitHub Actions
/ build

'Bug.State' does not contain a definition for 'Deferred'
            bug.Close();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReopenedState_WhenTested_ThrowsInvalidOperation()
        {
            var bug = new Bug(Bug.State.Reopened);
            bug.Test();
        }

        [TestMethod]
        public void ComprehensiveWorkflow_WithAllTransitions_SuccessfullyCompletes()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            bug.Defer();
            bug.Assign();
            bug.Resolve();
            bug.Test();
            bug.Reject();
            bug.Reopen();
            bug.Assign();
            bug.Resolve();
            bug.Verify();
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.GetState());
        }
    }
}
