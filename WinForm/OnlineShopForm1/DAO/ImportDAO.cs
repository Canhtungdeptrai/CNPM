using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopForm1.DAO
{
    public class ImportDAO
    {
        private static ImportDAO instance;

        public static ImportDAO Instance
        {
            get { if (instance == null) instance = new ImportDAO(); return ImportDAO.instance; }
            private set { ImportDAO.instance = value; }
        }

        private ImportDAO() { }

        public bool InsertFormIn(DateTime create, int idBatch, int status)
        {
            string query = string.Format("INSERT dbo.ImportForm ([Create],IDbatch,[status]) VALUES ('{0}',{1},{2})", create, idBatch,status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateInForm(DateTime create, int idBatch, int status, int id)
        {
            string query = string.Format("UPDATE dbo.ImportForm SET [create] = '{0}', IDbatch = {1}, [status] = {2} WHERE id = {3}", create, idBatch, status, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteInForm(int idBatch)
        {
            string query = string.Format("Delete ImportForm where id = {0}", idBatch);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
