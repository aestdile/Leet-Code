public class TaskManager {
    record Task (int userId, int taskId, int priority);

    SortedSet<int> priorities;
    Dictionary<int, SortedSet<int>> tasksByPriority = new();
    Dictionary<int, Task> tasksById;

    public TaskManager(IList<IList<int>> tasks) {
        tasksById = tasks.ToDictionary(t => t[1], t => new Task(t[0], t[1], t[2]));

        foreach (var group in tasks.GroupBy(t => t[2])) {
            SortedSet<int> taskIds = new(group.Select(t => t[1]).ToArray());
            tasksByPriority[group.Key] = taskIds;
        }

        priorities = new(tasksByPriority.Keys);
    }

    public void Add(int userId, int taskId, int priority) {
        tasksById[taskId] = new(userId, taskId, priority);
  
        if (!tasksByPriority.ContainsKey(priority)) {
            tasksByPriority[priority] = new() { taskId };
            priorities.Add(priority);
        } else {
            tasksByPriority[priority].Add(taskId);    
        }
    }
   
    public void Edit(int taskId, int newPriority) {
        Task task = tasksById[taskId];
        if (task.priority == newPriority) return;
        Rmv(taskId);
        Add(task.userId, taskId, newPriority);
    }
    
    public void Rmv(int taskId) {
        int priority = tasksById[taskId].priority;
        tasksById.Remove(taskId);

        tasksByPriority[priority].Remove(taskId);
        
        if (tasksByPriority[priority].Count == 0) {
            tasksByPriority.Remove(priority);
            priorities.Remove(priority);
        }  
    }
    
    public int ExecTop() {
        if (tasksById.Count == 0) return -1;

        int taskId = tasksByPriority[priorities.Max].Max;
        int userId = tasksById[taskId].userId;

        Rmv(taskId);

        return userId;
    }
}
