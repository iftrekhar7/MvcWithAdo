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
    public class StudentRepo
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string CS = ConfigurationManager.ConnectionStrings["Test"].ToString();
            con = new SqlConnection(CS);
        }

        //public List<Student> GetStudent()
        //{
        //    try
        //    {
        //        List<Student> stdList = new List<Student>();
        //        connection();
        //        SqlCommand cmd = new SqlCommand("Sp_GetStudent", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlDataReader rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            Student std = new Student();
        //            std.StudentId = Convert.ToInt32(rdr["StudentId"]);
        //            std.Name = rdr["Name"].ToString();
        //            std.Roll = rdr["Roll"].ToString();
        //            std.DeptId = Convert.ToInt32(rdr["DeptId"]);

        //            Dept dpt = new Dept();
        //            dpt.DeptId = Convert.ToInt32(rdr["DeptId"]);
        //            dpt.Name = rdr["Name"].ToString();

        //            std.Dept = dpt;

        //            stdList.Add(std);
        //        }

        //        if (rdr != null)
        //            rdr.Close();
        //        return stdList;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}

        public List<Student> GetStudent()
        {
            connection();
            List<Student> stdList = new List<Student>();


            SqlCommand com = new SqlCommand("Sp_GetStudent", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Dept dpt = new Dept();


                dpt.DeptId = Convert.ToInt32(dr["DeptId"]);// here found student Id 
                dpt.Name = Convert.ToString(dr["DeptName"]);// here found student name 


                stdList.Add(
                    new Student
                    {
                        StudentId = Convert.ToInt32(dr["StudentId"]),
                        Name = Convert.ToString(dr["StudentName"]),
                        Roll = Convert.ToString(dr["Roll"]),
                        DeptId = Convert.ToInt32(dr["DeptId"]),
                        Dept = dpt
                    }
                    );


            }

            return stdList;
        }

        public bool AddStudent(Student std)
        {

            connection();
            SqlCommand com = new SqlCommand("Sp_AddStudent", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", std.Name);
            com.Parameters.AddWithValue("@Roll", std.Roll);
            com.Parameters.AddWithValue("@DeptId", std.DeptId); 

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

        public bool EditStudent(Student std)
        {

            connection();
            SqlCommand com = new SqlCommand("Sp_EditStudent", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DeptId", std.StudentId);
            com.Parameters.AddWithValue("@Name", std.Name);
            com.Parameters.AddWithValue("@Roll", std.Roll);
            com.Parameters.AddWithValue("@DeptId", std.DeptId);
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

        public bool DeleteStudent(int id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteStudent", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StudentId", id);

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