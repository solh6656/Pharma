using Newtonsoft.Json;
using Pharma.Data.IRepositories;
using Pharma.Domin.Enttes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pharma.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {


        public abstract long lastId { get; set; }
        public abstract string path { get; set; }

        public GenericRepository()
        {
            dynamic appSettings = ReadFromAppSetting();

        }

        public T Create(T source)
        {
            IEnumerable<T> allT = GetAll();

            source.Id = ++lastId;
            source.CreatedTime = DateTime.Now;

            File.WriteAllText(path, JsonConvert.SerializeObject(allT.Append(source), Formatting.Indented));

            SaveToAppSetting();

            return source;

        }

        public bool Delete(long id)
        {
            var t = GetAll().FirstOrDefault(p => p.Id == id);

            if (t is null)
                return false;

            var ts = GetAll().Where(x => x.Id != id);

            WriteToFile(ts);

            return true;
        }

        public T Get(long id)
            => GetAll().FirstOrDefault(x => x.Id == id);

        public IEnumerable<T> GetAll()
        {
            string reader = File.ReadAllText(path);

            if (string.IsNullOrEmpty(reader))
                reader = "[]";

            return JsonConvert.DeserializeObject<IEnumerable<T>>(reader);

        }


        public T Update(long id, T source)
        {
            var ts = GetAll().Select(p => p.Id == id ? source : p);

            WriteToFile(ts);

            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public abstract void WriteToFile(IEnumerable<T> source);

        public abstract void SaveToAppSetting();

        public abstract dynamic ReadFromAppSetting();


    }
}
