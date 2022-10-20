using LogisticsManagement.DataLayer;
using System.Data.SqlClient;
using LogisticsManagement.Models;

namespace LogisticsManagement.Repository
{
    public class AWBRepository
    {
        SQLUtils db;

        public AWBRepository(SQLUtils db)
        {
            this.db = db;
        }

        /// <summary>
        /// Get Status for the provided AWB
        /// </summary>
        /// <param name="AWB">AWB Number</param>
        /// <returns>Details of AWB</returns>
        public AWB GetStatus(int AWB)
        {
            SqlDataReader reader = db.GetReader($"select awb_number, status_value, sender, reciever from AWBStatus as t1 inner join Status as t2 " +
                                                 $"on t1.status_type = t2.status_type where awb_number={AWB}");
            if(reader.Read())
            {
                return new AWB(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
            return null;
           
        }

        /// <summary>
        /// List all AWBs
        /// </summary>
        /// <returns>All AWBs</returns>
        public List<AWB> GetAllAWBs()
        {
            List<AWB> awb_list = new List<AWB>();
            SqlDataReader reader = db.GetReader($"select awb_number, status_value, sender, reciever from AWBStatus as t1 inner join Status as t2 " +
                                                 $"on t1.status_type = t2.status_type");
            while (reader.Read())
            {
                awb_list.Add(new AWB(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
            return awb_list;

        }

        /// <summary>
        /// Update the status of AWB
        /// </summary>
        /// <param name="AWB">AWB Number</param>
        /// <param name="status">new status value</param>
        /// <returns>Count of Affected Rows</returns>
        public int ChangeStatus(int AWB, int status)
        {
            SqlCommand sqlCommand = db.GetCommand($"update AWBStatus Set status_type = {status} where awb_number={AWB}");
            int affectedRows = sqlCommand.ExecuteNonQuery();
            return affectedRows;

        }

        /// <summary>
        /// Add new AWB
        /// </summary>
        /// <param name="status_type">Status of Current AWB</param>
        /// <param name="senderDetails">Sender Details</param>
        /// <param name="recieverDetails">Reciever Details</param>
        /// <returns>Count of Affected Rows</returns>
        public int AddNewAWB(int status_type, string senderDetails, string recieverDetails)
        {
            SqlCommand sqlCommand = db.GetCommand($"insert into AWBStatus (status_type, sender, reciever) values ({status_type},'{senderDetails}','{recieverDetails}')");
            int newAWB = (int)sqlCommand.ExecuteNonQuery();
            return newAWB;

        }

        /// <summary>
        /// Delete the AWB Provided
        /// </summary>
        /// <param name="awb">AWB number to be deleted</param>
        /// <returns>Count of Affected rows</returns>
        public int DeleteAWB(int awb)
        {
            SqlCommand sqlCommand = db.GetCommand($"delete from AWBStatus where awb_number={awb}");
            int newAWB = (int)sqlCommand.ExecuteNonQuery();
            return newAWB;

        }
    }
}
