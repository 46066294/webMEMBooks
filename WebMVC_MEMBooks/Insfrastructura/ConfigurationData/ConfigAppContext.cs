using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Insfrastructura.ConfigurationData
{
    public class ConfigAppContext:EntityTypeConfiguration<Insfrastructura.AppContext>
    {
        public ConfigAppContext()
        {

        }
    }
}
