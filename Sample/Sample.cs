//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Data.ConnectionUI;

namespace Sample
{
	public class Sample
	{
		// Sample 1: 
		[STAThread]
		static void Main(string[] args)
		{
			DataConnectionDialog dcd = new DataConnectionDialog();
			DataConnectionConfiguration dcs = new DataConnectionConfiguration(null);
			dcs.LoadConfiguration(dcd);

			if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
			{
				// load tables
				using (SqlConnection connection = new SqlConnection(dcd.ConnectionString))
				{
					connection.Open();
					SqlCommand cmd = new SqlCommand("SELECT * FROM sys.Tables", connection);

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							Console.WriteLine(reader.HasRows);
						}
					}

				}
			}

			dcs.SaveConfiguration(dcd);
		}

		// Sample 2: 
		//[STAThread]
		//static void Main(string[] args)
		//{
		//    DataConnectionDialog dcd = new DataConnectionDialog();
		//    DataConnectionConfiguration dcs = new DataConnectionConfiguration(null);
		//    dcs.LoadConfiguration(dcd);
		//    //dcd.ConnectionString = "Data Source=ziz-vspro-sql05;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=Admin_007";


		//    if (DataConnectionDialog.Show(dcd) == DialogResult.OK)
		//    {
		//        // load tables
		//        using (SqlConnection connection = new SqlConnection(dcd.ConnectionString))
		//        {
		//            connection.Open();
		//            SqlCommand cmd = new SqlCommand("SELECT * FROM sys.Tables", connection);

		//            using (SqlDataReader reader = cmd.ExecuteReader())
		//            {
		//                while (reader.Read())
		//                {
		//                    Console.WriteLine(reader.HasRows);
		//                }
		//            }

		//        }
		//    }

		//    dcs.SaveConfiguration(dcd);
		//}
	}
}
