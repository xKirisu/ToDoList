using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class TaskManage
    {
        string task_save = "task_save.json";
        Dictionary<DateOnly, BindingList<TDTask>> TaskDict = new Dictionary<DateOnly, BindingList<TDTask>>();

        public void addTask(TDTask task)
        {
            if (!TaskDict.ContainsKey(task.Date))
            {
                TaskDict[task.Date] = new BindingList<TDTask>();
            }

            TaskDict[task.Date].Add(task);
        }
        public void removeTask(TDTask task)
        {
            if (TaskDict.ContainsKey(task.Date))
            {
                TaskDict[task.Date].Remove(task);
            }
        }
        public BindingList<TDTask> GetTasks(DateOnly dateOnly)
        {
            if (TaskDict.ContainsKey(dateOnly))
            {
                return TaskDict[dateOnly];
            }
            else
            {
                BindingList<TDTask> empty_list = new BindingList<TDTask>();
                return empty_list;
            }
        }

        public BindingList<TDTask> GetAllTasks()
        {
            List<TDTask> list = new List<TDTask>();

            foreach (var task in TaskDict)
            {
                list.AddRange(task.Value);
            }

            BindingList<TDTask> bindingList = new BindingList<TDTask>(list);
            return bindingList;
        }
        public BindingList<TDTask> GetOverduedTasks()
        {
            List<TDTask> list = new List<TDTask>();
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            foreach (var task in TaskDict)
            {
                DateOnly date = task.Key;

                if(date <= today)
                {
                    list.AddRange(task.Value);
                }
            }

            BindingList<TDTask> bindingList = new BindingList<TDTask>(list);
            return bindingList;
        }
        public BindingList<TDTask> GetTaskByName(string text)
        {
            BindingList<TDTask> list = new BindingList<TDTask>();

            foreach (var tasks in TaskDict)
            {
                foreach(var task in tasks.Value)
                {
                    if (task.Name.ToLower().Contains(text.ToLower()))
                    {
                        list.Add(task);
                    }
                }
                
            }

            return list;
        }
        public BindingList<TDTask> GetTaskByName(string text, DateOnly date)
        {
            BindingList<TDTask> list = new BindingList<TDTask>();

            if (TaskDict.ContainsKey(date))
            {
                BindingList<TDTask> searched_list = TaskDict[date];

                foreach (var task in searched_list)
                {
                    if (task.Name.ToLower().Contains(text.ToLower()))
                    {
                        list.Add(task);
                    }
                }

            }

            return list;
        }

        public BindingList<TDTask> GetTaskByNameOverdued(string text)
        {
            BindingList<TDTask> list = new BindingList<TDTask>();
            List<TDTask> searched_list = new List<TDTask>();

            DateOnly date = DateOnly.FromDateTime(DateTime.Today);

            foreach(var task in TaskDict)
            {
                if(task.Key <= date)
                {
                    searched_list.AddRange(task.Value);
                }
            }

            foreach (var task in searched_list)
            {
                if (task.Name.ToLower().Contains(text.ToLower()))
                {
                    list.Add(task);
                }
            }

            return list;
        }

        public TaskManage()
        {
            LoadFromFile();
        }
        void LoadFromFile()
        {
            if (File.Exists(task_save)) {
                List<TDTask> alltasks = new List<TDTask>();

                using(StreamReader sr = new StreamReader(task_save))
                {
                    string json = sr.ReadToEnd();

                    if(json.Length > 0)
                    {
                        alltasks = JsonSerializer.Deserialize<List<TDTask>>(json);
                    }
                }

                if (alltasks != null)
                {
                    foreach (TDTask task in alltasks)
                    {
                        addTask(task);
                    }
                }
            }
            else
            {
                File.Create(task_save).Close();
            }
        }
        public void SaveToFile(object sender, EventArgs e)
        {
            List<TDTask> taskslist = new List<TDTask>();
            foreach(var task in TaskDict)
            {
                taskslist.AddRange(task.Value);
            }
            
            string json = JsonSerializer.Serialize(taskslist);

            if (!File.Exists(task_save))
            {
                File.Create(task_save).Close();
            }

            using(StreamWriter  sw = new StreamWriter(task_save))
            {
                sw.Write(json);
            }
        }
    }
}
