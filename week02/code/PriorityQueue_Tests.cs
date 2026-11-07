using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities (A: 1, B: 5, C: 3) and dequeue once.
    // Expected Result: The item with the highest priority ("B") should be returned and removed.
    // Defect(s) Found: Dequeue did not remove the item from the queue (_queue.RemoveAt was missing).
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("B", result);
        Assert.AreEqual("[A (Pri:1), C (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue items where multiple items share the highest priority (A: 5, B: 2, C: 5).
    // Expected Result: The item closest to the front ("A") should be dequeued before "C" (FIFO order).
    // Defect(s) Found: Dequeue used >= instead of >, which caused it to pick the last item with highest priority instead of the first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 5);

        var first = priorityQueue.Dequeue();
        Assert.AreEqual("A", first);

        var second = priorityQueue.Dequeue();
        Assert.AreEqual("C", second);

        var third = priorityQueue.Dequeue();
        Assert.AreEqual("B", third);
    }

    [TestMethod]
    // Scenario: Enqueue items where the highest priority item is at the very back of the queue (A: 1, B: 2, C: 10).
    // Expected Result: "C" with priority 10 should be returned.
    // Defect(s) Found: The loop in Dequeue was condition `index < _queue.Count - 1`, skipping the last element completely.
    public void TestPriorityQueue_HighestAtEnd()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("C", result);
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty PriorityQueue.
    // Expected Result: An InvalidOperationException should be thrown with message "The queue is empty."
    // Defect(s) Found: None. The empty check threw the proper exception and message.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message));
        }
    }
}