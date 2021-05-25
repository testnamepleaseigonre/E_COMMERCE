using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;

namespace E_COMMERCE.AllUsersData
{
    class UsersRepository
    {
        private static List<User> usersList;
        private SqlConnection conn = new SqlConnection(@"Server=.;Database=UsersData;User Id=sa;Password=Thedizzy069");

        public UsersRepository()
        {
            if (usersList == null)
            {
                usersList = new List<User>();
                //usersList.Add(new User("Valdemar", "Subotkovski", DateTime.Now, "admin", "admin", "C:\\Users\\valde\\Desktop\\II Kursas\\OOP\\2\\GUI\\images\\admin_default.png", "admin"));
            }
        }

        public void Register(User user)
        {
            try
            {
                CheckIfUsernameFree(user.GetUserName());
                string sql = "insert into users_table (name, surname, username, password, birthDate, userType, imageLocation) values (@name, @surname, @username, @password, @birthDate, @userType, @imageLocation)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", user.GetName());
                cmd.Parameters.AddWithValue("@surname", user.GetSurname());
                cmd.Parameters.AddWithValue("@username", user.GetUserName());
                cmd.Parameters.AddWithValue("@password", user.GetPassword());
                cmd.Parameters.AddWithValue("@birthDate", user.GetBirthDate());
                cmd.Parameters.AddWithValue("@userType", "user");
                cmd.Parameters.AddWithValue("@imageLocation", "user_pics/user_default.png");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                addBirthdayPromotion(getUserID(user.GetUserName()));
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        private void addBirthdayPromotion(int userID)
        {
            try
            {
                string sql = "insert into promotions_offers (title, active, use_date, userID, value) values (@title, @active, @use_date, @userID, @value)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", "10% OFF discount, birthday is close!");
                cmd.Parameters.AddWithValue("@active", "no");
                cmd.Parameters.AddWithValue("@use_date", "2000-01-01");
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@value", "10");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public User Login(string username, string password)
        {
            try
            {
                string sql = "select id, name, surname, username, birthDate, userType, imageLocation from users_table where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();

                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string id = dataReader["id"].ToString();
                        string name = dataReader["name"].ToString();
                        string surname = dataReader["surname"].ToString();
                        string uname = dataReader["username"].ToString();
                        DateTime birthDate = DateTime.Parse(dataReader["birthDate"].ToString());
                        string userType = dataReader["userType"].ToString();
                        string imageLocation = dataReader["imageLocation"].ToString();
                        return new User(id, name, surname, birthDate, username, "  ", imageLocation, userType);
                    }
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                throw new Exception(exc.Message);
            }
            conn.Close();
            throw new Exception("Bad Credentials!");
        }

        public void removeUser(string username)
        {
            try
            {
                int userid = getUserID(username);
                removeUsersComments(userid);
                removeUsersWishList(userid);
                removeUserCart(userid);
                removeUserPromotions(userid);
                string sql = "delete from users_table where id=@userid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userid", userid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception exc)
            {
                conn.Close();
                throw new Exception(exc.Message);
            }
        }
        private void removeUserPromotions(int userid)
        {
            try
            {
                string sql = "delete from promotions_offers where userID=@userid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userid", userid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Couldn't remove users Promotions");
            }
        }
        private void removeUserCart(int userid)
        {
            try
            {
                string sql = "delete from cart_items where userID=@userid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userid", userid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Couldn't remove users Cart");
            }
        }

        private void removeUsersWishList(int userid)
        {
            try
            {
                string sql = "delete from wishlist_table where userID=@userid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userid", userid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Couldn't remove users WishList");
            }
        }

        private void removeUsersComments(int userid)
        {
            try
            {
                string sql = "delete from comments_table where user_id=@userid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userid", userid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Couldn't remove users comments");
            }        
        }

        private int getUserID(string username)
        {
            string sql = "select id from users_table where username=@username";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username);
            conn.Open();
            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    int userid = int.Parse(dataReader["id"].ToString());
                    conn.Close();
                    return userid;
                }
            }
            conn.Close();
            throw new Exception("Error");
        }

        public void checkIfDataValid(string username, string password)
        {
            if(username == "" || username == null)
                throw new Exception("Username field is empty!");
            if (password == "" || password == null)
                throw new Exception("Password field is empty!");
        }

        public void CheckIfUsernameFree(string username)
        {
            string sql = "select username from users_table";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    if(username == dataReader["username"].ToString())
                    {
                        conn.Close();
                        throw new Exception("Username is already in use!");
                    }
                }
            }
            conn.Close();
        }

        public List<User> GetUsersList()
        {
            usersList.Clear();
            string sql = "select id, name, surname, username, password, birthDate, userType, imageLocation from users_table where userType='user'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    string id = dataReader["id"].ToString();
                    string name = dataReader["name"].ToString();
                    string surname = dataReader["surname"].ToString();
                    string uname = dataReader["username"].ToString();
                    string pass = dataReader["password"].ToString();
                    DateTime birthDate = DateTime.Parse(dataReader["birthDate"].ToString());
                    string imageLocation = dataReader["imageLocation"].ToString();
                    string userType = dataReader["userType"].ToString();
                    usersList.Add(new User(id, name, surname, birthDate, uname, pass, imageLocation, userType));
                }
            }
            conn.Close();
            return usersList;
        }
        public string getUsernameByUserId(int userID)
        {
            string username= null;
            string sql = "select username from users_table where id=@userID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            conn.Open();
            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    username = dataReader["username"].ToString();
                }
            }
            conn.Close();
            return username;
        }
    }
}
