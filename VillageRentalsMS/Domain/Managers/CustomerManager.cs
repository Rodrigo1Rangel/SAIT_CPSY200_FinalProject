﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using VillageRentalsMS.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VillageRentalsMS.Domain.Managers
{
    internal class CustomerManager
    {
        // ==========================================  METHODS =========================================

        /// <summary>
        /// Blob.
        /// </summary>
        /// <param name="value">Blob.</param>
        /// <returns>Blob.</returns>
        public static void AddCustomer(string new_last_name, string new_first_name, string new_contact_phone, string new_email, string new_note)
        {
            OracleConnection conn = DatabaseSingleton.Connection;
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT MAX(customer_id) FROM vr_customerinfo";

            OracleDataReader reader = cmd.ExecuteReader();

            // A single value will be returned, from which we will read the highest customer_id number
            // that was added into the system. We will automatically create a new id based on that one.
            reader.Read();
            int new_customer_id = reader.GetInt32(0) + 1;

            string sql = "INSERT INTO vr_customerinfo(customer_id, last_name, first_name, contact_phone, email, note) VALUES(:param1, :param2, :param3, :param4, :param5, :param6)";

            OracleCommand command = new OracleCommand(sql, conn);
            command.Parameters.Add(new OracleParameter("param1", OracleDbType.Int32)).Value = new_customer_id;
            command.Parameters.Add(new OracleParameter("param2", OracleDbType.Varchar2)).Value = new_last_name;
            command.Parameters.Add(new OracleParameter("param3", OracleDbType.Varchar2)).Value = new_first_name;
            command.Parameters.Add(new OracleParameter("param4", OracleDbType.Varchar2)).Value = new_contact_phone;
            command.Parameters.Add(new OracleParameter("param5", OracleDbType.Varchar2)).Value = new_email;
            command.Parameters.Add(new OracleParameter("param6", OracleDbType.Varchar2)).Value = new_note;

            command.ExecuteNonQuery();

            cmd.Dispose();
        }

        /// <summary>
        /// Blob.
        /// </summary>
        /// <param name="value">Blob.</param>
        /// <returns>Blob.</returns>
        public static void EditCustomer(int customer_id, string new_last_name, string new_first_name, string new_contact_phone, string new_email, string new_note)
        {
            OracleConnection conn = DatabaseSingleton.Connection;

            string sql_to_update =
                $"UPDATE vr_customerinfo " +
                $"SET LAST_NAME = ':{new_last_name}', " +
                $"FIRST_NAME = '{new_first_name}', " +
                $"CONTACT_PHONE = '{new_contact_phone}', " +
                $"EMAIL = '{new_email}', " +
                $"NOTE = '{new_note}' " +
                $"WHERE CUSTOMER_ID = {customer_id}";

            OracleDataAdapter adapter = new OracleDataAdapter(sql_to_update, conn);

            OracleCommand command = new OracleCommand(sql_to_update, conn);

            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();

            adapter.Dispose();
        }
    }
}
