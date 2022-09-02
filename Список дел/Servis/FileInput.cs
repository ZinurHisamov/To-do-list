using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Список_дел.Models;

namespace Список_дел.Servis
{
    class FileInput
    {
        private readonly string PATH;
        public FileInput(string path)
        {
            PATH = path;
        }
        public BindingList<TodoModel> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoModel>();
            }
            using(var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
            }
        }
        
        public void SaveData(object _TodoDateLis)
        {
            using (StreamWriter stream = File.CreateText(PATH))
            {

                string output = JsonConvert.SerializeObject(_TodoDateLis);
                stream.Write(output);
            }

        }
    }
}
