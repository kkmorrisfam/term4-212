using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Converters;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
    // Scenario: I am looking to see if the last item added to the queue shows up at the end of the queue.
    // Expected Result: "[Bob(4), Levi (2), Bryce (6), Madison (1) ]"
    // Defect(s) Found: none for this one
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 4);
        priorityQueue.Enqueue("Levi", 2);
        priorityQueue.Enqueue("Bryce", 6);
        priorityQueue.Enqueue("Madison", 1);

        string expectedResults = "[Bob(4), Levi (2), Bryce (6), Madison (1) ]";
        string actualResults = priorityQueue.ToString();
        Assert.AreEqual(expectedResults, actualResults);     


    }

    [TestMethod]
    // The Dequeue function shall remove the item with the highest priority and return its value.
    // Scenario: High priority item is high number, low priority is low number, looking for the highest number
    // Expected Result: Bryce
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();         

        priorityQueue.Enqueue("Bob", 4);
        priorityQueue.Enqueue("Levi", 2);
        priorityQueue.Enqueue("Bryce", 6);
        priorityQueue.Enqueue("Madison", 1);

        string highestPriorityItem = priorityQueue.Dequeue();
        string expectedValue = "Bryce";

        Assert.AreEqual(expectedValue, highestPriorityItem);
    }


    [TestMethod]
    //If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
    // Scenario: I need to test for two or more identical high priority items, and choose that entered the queue first
    // Expected Result: Miranda
    // Defect(s) Found: Returns the last highest priority item, not the first
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 4);
        priorityQueue.Enqueue("Levi", 2);
        priorityQueue.Enqueue("Bryce", 6);
        priorityQueue.Enqueue("Madison", 1);
        priorityQueue.Enqueue("Miranda", 9);
        priorityQueue.Enqueue("Katy", 4);
        priorityQueue.Enqueue("Alden", 9);
        priorityQueue.Enqueue("Vixie", 1);

        string expectedValue = "Miranda";
        string highestPriorityItem = priorityQueue.Dequeue();        

        Assert.AreEqual(expectedValue, highestPriorityItem);
        // Assert.Fail("Implement the test case and then remove this.");
    }


    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}