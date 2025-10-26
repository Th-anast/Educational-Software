using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace e_learning
{
    internal class Query
    {
        public static string am, name, surname;

        readonly SQLiteConnection conn = new SQLiteConnection("Data Source=DB.db;Version=3;");

        public string GetFullName()
        {
            return name + ' ' + surname;
        }

        public void Register(string AM, string Name, string Surname, string username, string password)
        {
            am = AM;
            name = Name;
            surname = Surname;
            conn.Open();
            string insertQuery = "Insert into Student(AM,Name,Surname,Username,Password) values(@am,@name,@surname,@username,@password)";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@am", am);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool Login(string username, string password)
        {
            bool flag = false;
            conn.Open();
            string selectQuery = "Select * from Student where Username=@username and Password=@password";
            SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                flag = true;
                am = reader.GetString(1);
                name = reader.GetString(2);
                surname = reader.GetString(3);
            }
            conn.Close();
            return flag;
        }

        public void InsertData(string title, string section)
        {
            conn.Open();
            string insertQuery = "Insert into Course(AM_student,Title,Section,Grade) values(@am,@title,@section,0)";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@am", am);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@section", section);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void InsertProgress(string course, int chapterScore, string chapter)
        {
            string query;
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand("Select count(*) from Progress where AM_student=@am and Course=@course", conn);
            cmd.Parameters.AddWithValue("@am", am);
            cmd.Parameters.AddWithValue("@course", course);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0) query = "Insert into Progress(AM_student,Course,Chapter1,Chapter2,Chapter3,AllChapters) values(@am,@course,@chapterScore,0,0,0)";
            else query = "Update Progress set "+ chapter + "=@chapterScore where AM_student=@am and Course=@course";   
            cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@am", am);
            cmd.Parameters.AddWithValue("@course", course);
            cmd.Parameters.AddWithValue("@chapterScore", chapterScore);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SelectProgress(string course)
        {
            conn.Open();
            string selectQuery = "Select * from Progress where AM_student=@am and Course=@course";
            SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
            command.Parameters.AddWithValue("@am", am);
            command.Parameters.AddWithValue("@course", course);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Form6.ch_progress.Add(reader.GetInt32(3));
                Form6.ch_progress.Add(reader.GetInt32(4));
                Form6.ch_progress.Add(reader.GetInt32(5));
                Form6.ch_progress.Add(reader.GetInt32(6));
            }
            conn.Close();
        }

        public string SelectCourse(bool flag)
        {
            conn.Open();
            string selectQuery = "Select * from Course where AM_student=@am";
            SQLiteCommand command = new SQLiteCommand(selectQuery, conn); 
            command.Parameters.AddWithValue("@am", am);
            SQLiteDataReader reader = command.ExecuteReader();
            string str = string.Empty;
            while (reader.Read())
            {
                if (flag) str += reader.GetString(2) + ',';
                else str += reader.GetString(3) + '/';
            }
            conn.Close();
            return str;
        }

        public float GetMO(string section)
        {
            conn.Open();
            string selectQuery = "Select * from Course where AM_student=@am and Section=@section";
            SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
            command.Parameters.AddWithValue("@am", am);
            command.Parameters.AddWithValue("@section", section);
            SQLiteDataReader reader = command.ExecuteReader();
            float mo = 0;
            while (reader.Read())
            {
                mo+=reader.GetInt32(4);
            }
            conn.Close();
            mo /= 2;
            return mo;
        }

        public void UpdateGrade(int grade, string title)
        {
            conn.Open();
            string updateQuery = "Update Course set Grade=@grade where AM_student=@am and Title=@title";
            SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("@am", am);
            cmd.Parameters.AddWithValue("@grade", grade);            
            cmd.Parameters.AddWithValue("@title", title);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
