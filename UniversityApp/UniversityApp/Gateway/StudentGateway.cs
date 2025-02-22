﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UniversityApp.Models;
using UniversityApp.UI;

namespace UniversityApp.Gateway
{
    public class StudentGateway
    {
        ConnectionDatabase connectionDatabase=new ConnectionDatabase();
        public int SubmitStudent(Student astudent)
        {
            //SqlConnection connection = new SqlConnection("Data Source=MOHAMMAD-IMRAN;Initial Catalog=University_Info;Persist Security Info=True;User ID=sa;Password=imran");
            // connection.Open();
            //SqlCommand command = new SqlCommand(query, connection);
            //connection.Close();
            //string query = "INSERT INTO Student_data (Name,StudentID,Email,Department,Phone,RegNo,Gender,BloodGroup,HallName,Address,University) VALUES('" + astudent.Name + "','" + astudent.StudentID + "','" + astudent.Email + "','" + astudent.Department + "','" + astudent.Phone + "','" + astudent.RegNo + "','" + astudent.Gender + "','" + astudent.BloodGroup + "','" + astudent.HallName + "','" + astudent.Address + "','" + astudent.University + "')";
            string query = "INSERT INTO Student_data (Name,StudentID,Email,Department,Phone,RegNo,Gender,BloodGroup,HallName,Address,University) VALUES(@Name,@StudentID,@Email,@Department,@Phone,@RegNo,@Gender,@BloodGroup,@HallName,@Address,@University)"; 


            SqlCommand command = new SqlCommand(query, connectionDatabase.GetConnection());
            command.Parameters.Clear();
            command.Parameters.AddWithValue("Name", astudent.Name);
            command.Parameters.AddWithValue("StudentID", astudent.StudentID);
            command.Parameters.AddWithValue("Email", astudent.Email);
            command.Parameters.AddWithValue("Department", astudent.Department);
            command.Parameters.AddWithValue("Phone", astudent.Phone);
            command.Parameters.AddWithValue("RegNo", astudent.RegNo);
            command.Parameters.AddWithValue("Gender", astudent.Gender);
            command.Parameters.AddWithValue("BloodGroup", astudent.BloodGroup);
            command.Parameters.AddWithValue("HallName", astudent.HallName);
            command.Parameters.AddWithValue("Address", astudent.Address);
            command.Parameters.AddWithValue("University", astudent.University);
            int rowCount = command.ExecuteNonQuery();
           connectionDatabase.CloseConnection();
           
            return rowCount;
            //Another way to set command and execute command
            //command.CommandText = query;
            //command.Connection = connection;
        }
        public bool IsExistRegNo(string RegNo)
        {
            //SqlConnection connection = new SqlConnection("Data Source=MOHAMMAD-IMRAN;Initial Catalog=University_Info;Persist Security Info=True;User ID=sa;Password=imran");
            //connection.Open();
            string query = "SELECT * FROM Student_data WHERE  RegNo='" + RegNo + "'";
            SqlCommand command=new SqlCommand(query, connectionDatabase.GetConnection());
            //SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Student> GetAllStudents()
        {
            //SqlConnection connection = new SqlConnection("Data Source=MOHAMMAD-IMRAN;Initial Catalog=University_Info;Persist Security Info=True;User ID=sa;Password=imran");
            //connection.Open();
            string query = "SELECT * FROM Student_data";
            //SqlCommand command = new SqlCommand(query, connection);
            SqlCommand command = new SqlCommand(query, connectionDatabase.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            List<Student> students = new List<Student>();
            while(reader.Read())
            {
                Student student= new Student();
                student.Name            = reader["Name"].ToString();
                student.StudentID       = reader["StudentID"].ToString();
                student.Email           = reader["Email"].ToString();
                student.Department      = reader["Department"].ToString();
                student.Phone           = reader["Phone"].ToString();
                student.RegNo           = reader["RegNo"].ToString();
                student.Gender          = reader["Gender"].ToString();
                student.BloodGroup      = reader["BloodGroup"].ToString();
                student.HallName        = reader["HallName"].ToString();
                student.Address         = reader["Address"].ToString();
                student.University      = reader["University"].ToString();
                students.Add(student); 
            }
            //connection.Close();
            connectionDatabase.CloseConnection();
            return students;
        }
        public Student SearchStudentByRegNo(string RegNo)
        {
            //SqlConnection connection = new SqlConnection("Data Source=MOHAMMAD-IMRAN;Initial Catalog=University_Info;Persist Security Info=True;User ID=sa;Password=imran");
            //connection.Open();
            string query = "SELECT * FROM Student_data WHERE RegNo='"+RegNo+"'";
            // SqlCommand command = new SqlCommand(query, connection);
            SqlCommand command = new SqlCommand(query, connectionDatabase.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            Student student = new Student();
            while (reader.Read())
            {
               
                student.Name = reader["Name"].ToString();
                student.StudentID = reader["StudentID"].ToString();
                student.Email = reader["Email"].ToString();
                student.Department = reader["Department"].ToString();
                student.Phone = reader["Phone"].ToString();
                student.RegNo = reader["RegNo"].ToString();
                student.Gender = reader["Gender"].ToString();
                student.BloodGroup = reader["BloodGroup"].ToString();
                student.HallName = reader["HallName"].ToString();
                student.Address = reader["Address"].ToString();
                student.University = reader["University"].ToString();
            }
            // connection.Close();
            connectionDatabase.CloseConnection();
            return student;
        }

        public int DeleteStudent(string RegNo)
        {
           // SqlConnection connection = new SqlConnection("Data Source=MOHAMMAD-IMRAN;Initial Catalog=University_Info;Persist Security Info=True;User ID=sa;Password=imran");
           // connection.Open();
            string query = "DELETE FROM Student_data WHERE  RegNo='" + RegNo + "'";
            //SqlCommand command = new SqlCommand(query, connection);
            SqlCommand command = new SqlCommand(query, connectionDatabase.GetConnection());
            int rowCount=command.ExecuteNonQuery();
            return rowCount;    
        }
        public int UpdateStudent(Student student)
        {
           // SqlConnection connection = new SqlConnection("Data Source=MOHAMMAD-IMRAN;Initial Catalog=University_Info;Persist Security Info=True;User ID=sa;Password=imran");
            //connection.Open();
            string query = "UPDATE Student_data SET Name='" + student.Name + "',StudentID='" + student.StudentID + "',Email='" + student.Email + "',Department='" + student.Department + "',Phone='" + student.Phone + "',Gender='" + student.Gender + "',BloodGroup='" + student.BloodGroup + "',HallName='" + student.HallName + "',Address='" + student.Address + "',University='" + student.University + "' WHERE RegNo='" + student.RegNo + "' ";
            //SqlCommand command = new SqlCommand(query, connection);
            SqlCommand command = new SqlCommand(query, connectionDatabase.GetConnection());
            int rowCount = command.ExecuteNonQuery();
            return rowCount;
        }
        public List<Course> GetAllCourses()
        {
           
            string query = "SELECT * FROM Course_data";
            SqlCommand command = new SqlCommand(query,connectionDatabase.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while(reader.Read())
            {
                Course course = new Course();
                course.CourseID = (int)reader["CourseID"];
                course.CourseName = reader["CourseName"].ToString();
                courses.Add(course);
            }
            reader.Close();
            connectionDatabase.CloseConnection();
            return courses;
        }
        public int EnrollStudent(CourseEnroll courseEnroll)
        { 
            string query = "INSERT INTO CourseEnroll_data(StudentID,CourseCode,DateTime) VALUES('" + courseEnroll.StudentID + "','" + courseEnroll.CourseCode + "','" + courseEnroll.DateTime + "')";
            SqlCommand command=new SqlCommand(query, connectionDatabase.GetConnection());
            int rowCount = command.ExecuteNonQuery();
            connectionDatabase.CloseConnection();
            return rowCount;
        }
    }
}