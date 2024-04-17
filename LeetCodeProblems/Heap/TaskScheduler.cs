namespace LeetCodeProblems.Heap;
public class TaskScheduler
{
    // intuition
    // this problem can be solved by always running the task with the largest remaining occurences that is available to be run
    // to do this, we can use a max heap (a priority queue in C#) with the occurences of the values that are available to be run
    // and a queue with the values that have been run already and the time when cycle when they can be run again
    // for each cycle, we pop the task with the most occurences
    // decrement the occurences by one
    // and add it to the queue with the time it will be available to be run again
    // that time will be the current cycle + n
    // then we, if the cycle equals the available cycle of the first item in the queue, we pop it and add it back to the heap
    // in the end, we return the number of cycles

    // the time complexity of this solution will be O(n * m) where n is the number of tasks and m is the delay between tasks

    // this is a greedy solution and it works because the delay between tasks and the time to process tasks are both constant
    // meaning that the only value we can sort by that will affect the total number of cycles is the number of occurences of the most common task
    // I'm pretty sure this means that the minimum number of cycles could be expressed as an equation
    // if the number of tasks is less than the delay (n), then the number of cycles would be the count of the most common task multiplied by the delay
    // if the number of tasks is equal to n, then the number of cycles would be the same plus 1

    // but I think it is worth using the actual algorithm here, because if we had to do any actual work with the tasks, it would be more useful

    public int LeastInterval(char[] tasks, int n)
    {
        // count the occruences of each task
        Dictionary<char, int> taskOccurences = new Dictionary<char, int>();

        foreach (char task in tasks)
        {
            if (!taskOccurences.ContainsKey(task))
                taskOccurences[task] = 0;

            taskOccurences[task]++;
        }

        // create a max heap with the occurences of the tasks - we don't actually need the char values, but I don't know how to create a max heap with just the occurences in C#
        PriorityQueue<int, int> taskHeap = new (tasks.Length);

        // enqueue the task occurences
        foreach (var taskOccurence in taskOccurences)
            taskHeap.Enqueue(-taskOccurence.Value, -taskOccurence.Value);

        int cycle = 0;

        // create a queue to store the tasks that have been run and the cycle when they can be run again
        Queue<(int count, int cycle)> q = new();

        while(taskHeap.Count > 0 || q.Count > 0)
        {
            cycle++;

            if (taskHeap.Count > 0)
            {
                int task = taskHeap.Dequeue()+1;
                if (task < 0)
                    q.Enqueue((task, cycle + n));
            }

            if (q.Count > 0 && q.Peek().cycle == cycle)
            {
                (int count, int cycle) task = q.Dequeue();
                taskHeap.Enqueue(task.count, task.count);
            }
        }

        return cycle;
    }
}