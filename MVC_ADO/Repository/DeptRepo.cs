using MVC_ADO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_ADO.Repository
{
    public class DeptRepo
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string CS = ConfigurationManager.ConnectionStrings["Test"].ToString();
            con = new SqlConnection(CS);
        }

        public bool AddDept(Dept dept)
        {

            connection();
            SqlCommand com = new SqlCommand("Sp_AddDept", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", dept.Name);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Dept> GetDept()
        {
            connection();
            List<Dept> deptList = new List<Dept>();


            SqlCommand com = new SqlCommand("Sp_GetDept", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                deptList.Add(

                    new Dept
                    {

                        DeptId = Convert.ToInt32(dr["DeptId"]),
                        Name = Convert.ToString(dr["Name"])

                    }


                    );


            }

            return deptList;
        }

        public bool EditDept(Dept dept)
        {

            connection();
            SqlCommand com = new SqlCommand("Sp_EditDept", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DeptId", dept.DeptId);
            com.Parameters.AddWithValue("@Name", dept.Name);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

        public bool DeleteDept(int id)
        {

            connection();
            SqlCommand com = new SqlCommand("Sp_DeleteDept", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DeptId", id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
    }
}