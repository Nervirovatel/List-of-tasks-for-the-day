using List_of_tasks_for_the_day.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_of_tasks_for_the_day.Services
{
    class FileIOServices
    {
        private readonly string PATH;

        public FileIOServices(string path)
        {
            PATH = path;
        }
        public BindingList<Todo_Model> LoadDate()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Todo_Model>();
            }

            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Todo_Model>>(fileText);
            }
           
        }

        public void SaveData(object _TodoDateList)
        {
            using(StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(_TodoDateList);
                writer.Write(output);
            }
        }
    }
}
