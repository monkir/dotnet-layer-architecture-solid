using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class Repo
    {
        public OMSContext Db;
        public Repo(IDataRepository repository)
        {
            this.Db = new OMSContext(repository);
        }
    }
}
