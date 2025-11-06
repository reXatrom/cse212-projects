using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - this case is already handled correctly
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueue()
    {
        var queue = new PriorityQueue();
        var result = queue.Dequeue();
    }

    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of highest priority first
    // Defect(s) Found: Items not being removed from queue, incorrect loop bounds in Dequeue
    public void TestPriorityQueue_DifferentPriorities()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Low", 1);
        queue.Enqueue("High", 3);
        queue.Enqueue("Medium", 2);

        Assert.AreEqual("High", queue.Dequeue());
        Assert.AreEqual("Medium", queue.Dequeue());
        Assert.AreEqual("Low", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority
    // Expected Result: Items should be dequeued in FIFO order when priorities are equal
    // Defect(s) Found: FIFO order not maintained for same-priority items
    public void TestPriorityQueue_SamePriority()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("First", 1);
        queue.Enqueue("Second", 1);
        queue.Enqueue("Third", 1);

        Assert.AreEqual("First", queue.Dequeue());
        Assert.AreEqual("Second", queue.Dequeue());
        Assert.AreEqual("Third", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of same and different priorities
    // Expected Result: Higher priority items come first, with FIFO order for same priorities
    // Defect(s) Found: Items not being removed, FIFO order not maintained
    public void TestPriorityQueue_MixedPriorities()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Low1", 1);
        queue.Enqueue("High1", 3);
        queue.Enqueue("Medium1", 2);
        queue.Enqueue("High2", 3);
        queue.Enqueue("Low2", 1);
        queue.Enqueue("Medium2", 2);

        // Should dequeue High1 first (first high priority item)
        Assert.AreEqual("High1", queue.Dequeue());
        // Then High2 (second high priority item)
        Assert.AreEqual("High2", queue.Dequeue());
        // Then Medium1 (first medium priority item)
        Assert.AreEqual("Medium1", queue.Dequeue());
        // Then Medium2 (second medium priority item)
        Assert.AreEqual("Medium2", queue.Dequeue());
        // Then Low1 (first low priority item)
        Assert.AreEqual("Low1", queue.Dequeue());
        // Then Low2 (second low priority item)
        Assert.AreEqual("Low2", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Single item in queue
    // Expected Result: Should return the single item and empty the queue
    // Defect(s) Found: None - but good to test edge case
    public void TestPriorityQueue_SingleItem()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("OnlyOne", 1);
        
        Assert.AreEqual("OnlyOne", queue.Dequeue());
        
        // Queue should be empty now
        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
    }
}