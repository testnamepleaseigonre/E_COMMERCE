using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_COMMERCE.AllUsersData;
using System.Data.SqlClient;

namespace E_COMMERCE
{
    public class User : Person
    {
        private UsersRepository repository = new UsersRepository();
        private SqlConnection conn = new SqlConnection(@"Server=.;Database=UsersData;User Id=sa;Password=Thedizzy069");
        protected string id;
        protected string username;
        protected string password;
        protected string imageLocation;
        protected string userType;

        public User(string id, string name, string surname, DateTime birthDate, string username, string password, string imageLocation, string userType) : base(name, surname, birthDate)
        {
            repository.checkIfDataValid(username, password);
            this.id = id;
            this.username = username;
            this.password = password;
            this.imageLocation = imageLocation;
            this.userType = userType;
        }

        public string GetUserName()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }
        public string GetId()
        {
            return id;
        }

        public void SetPassword(string cpass, string password, string username)
        {
            string sqlCheck = "select password from users_table where username=@username";
            SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
            cmdCheck.Parameters.AddWithValue("@username", username);
            try
            {
                conn.Open();
                using (SqlDataReader dataReader = cmdCheck.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (dataReader["password"].ToString() != cpass)
                        {
                            conn.Close();
                            throw new Exception("Bad credentials!");
                        }
                    }
                }
                conn.Close();

                string sql = "update users_table set password=@password where username=@username and password=@cpass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@cpass", cpass);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                throw new Exception(exc.Message);
            }
            //this.password = password;
        }

        public void setImageLocation(string username)
        {
            string sql = "update users_table set imageLocation=@imageLocation where username=@username";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All files(*.*)|*.*| jpg files(*.jpg)|*.jpg| png files(*.png)|*.png";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.Copy(dialog.FileName, "user_pics/" + dialog.SafeFileName);
                        cmd.Parameters.AddWithValue("@imageLocation", "user_pics/" + dialog.SafeFileName);
                    }
                    catch
                    {
                        cmd.Parameters.AddWithValue("@imageLocation", "user_pics/" + dialog.SafeFileName);
                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    HomePage.LoggedInUser.imageLocation = "user_pics/" + dialog.SafeFileName;
                }
            }
            catch (Exception)
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }

        public string getImageLocation()
        {
            return  imageLocation;
        }

        public string getUserType()
        {
            return userType;
        }
        public void setUserType(string userType)
        {
            this.userType = userType;
        }
    }
}
