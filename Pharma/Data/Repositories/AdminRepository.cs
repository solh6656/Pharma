using Newtonsoft.Json;
using Pharma.Data.IRepositories;
using Pharma.Domin.Enttes;
using Pharma.Settings.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharma.Data.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public override long lastId { get; set; }
        public override string path { get; set; }
        public AdminRepository()
        {
            dynamic appSettings = ReadFromAppSetting();

            lastId = appSettings.Databases.Admin.LastId;

            path = appSettings.Databases.Admin.Path;

        }

        public override dynamic ReadFromAppSetting()
        {
            string json = File.ReadAllText(Constant.APP_SETTINGS_PATH);

            return JsonConvert.DeserializeObject<dynamic>(json);
        }

        public override void SaveToAppSetting()
        {
            dynamic appSettings = ReadFromAppSetting();
            appSettings.Databases.Admin.LastId = lastId;


            string json = JsonConvert.SerializeObject(appSettings, Formatting.Indented);
            File.WriteAllText(Constant.APP_SETTINGS_PATH, json);
        }

        public override void WriteToFile(IEnumerable<Admin> source)
        {
            string json = JsonConvert.SerializeObject(source);

            File.WriteAllText(path, json);
        }
    }
}
