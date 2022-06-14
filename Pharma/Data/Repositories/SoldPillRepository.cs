using Newtonsoft.Json;
using Pharma.Data.IRepositories;
using Pharma.Domin.Enttes;
using Pharma.Settings.Constants;
using System.Collections.Generic;
using System.IO;

namespace Pharma.Data.Repositories
{
    public class SoldPillRepository : GenericRepository<SoldPill>, ISoldPillRepository
    {
        public override long lastId { get; set; }
        public override string path { get; set; }
        public SoldPillRepository()
        {
            dynamic appSettings = ReadFromAppSetting();

            lastId = appSettings.Databases.SoldPill.LastId;

            path = appSettings.Databases.SoldPill.Path;

        }

        public override dynamic ReadFromAppSetting()
        {
            string json = File.ReadAllText(Constant.APP_SETTINGS_PATH);

            return JsonConvert.DeserializeObject<dynamic>(json);
        }

        public override void SaveToAppSetting()
        {
            dynamic appSettings = ReadFromAppSetting();
            appSettings.Databases.SoldPill.LastId = lastId;


            string json = JsonConvert.SerializeObject(appSettings, Formatting.Indented);
            File.WriteAllText(Constant.APP_SETTINGS_PATH, json);
        }

        public override void WriteToFile(IEnumerable<SoldPill> source)
        {
            string json = JsonConvert.SerializeObject(source);

            File.WriteAllText(path, json);
        }
    }
}
