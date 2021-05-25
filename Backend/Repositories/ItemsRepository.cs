using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using GUI.Backend.Models;
using System.Diagnostics;

namespace GUI.Backend.Repositories
{
    public class ItemsRepository
    {
        private SqlConnection conn;

        public ItemsRepository()
        {
            conn = new SqlConnection(@"Server=.;Database=UsersData;User Id=sa;Password=Thedizzy069");
        }

        public void addNewComment(string text, int itemID, int userID)
        {
            try
            {
                string sql = "insert into comments_table(item_id, user_id, date, text) values (@itemID, @userID, @date, @text)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@text", text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error");
            }
        }

        public void deleteComment(int itemID, int userID)
        {
            try
            {
                string sql = "delete from comments_table where item_id=@itemID and user_id=@userID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }

        public void deleteItem(int itemID)
        {
            try
            {
                deleteFromWishlist(itemID);
                deleteFromComments(itemID);
                deleteFromCarts(itemID);
                string sql = "delete from items_table where id=@itemID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                throw new Exception(exc.Message);
            }
        }

        private void deleteFromCarts(int itemID)
        {
            string sql = "delete from cart_items where item_id=@itemID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@itemID", itemID);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void deleteFromComments(int itemID)
        {
            string sql = "delete from comments_table where item_id=@itemID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@itemID", itemID);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void deleteFromWishlist(int itemID)
        {
            string sql = "delete from wishlist_table where itemID=@itemID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@itemID", itemID);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void addNewItem(string title, string price, string description, int categoryID, string image)
        {
            try
            {
                string sql = "insert into items_table(title, price, description, categoryID, image) values (@title, @price, @description, @categoryID, @image)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@categoryID", categoryID);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@image", image);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                throw new Exception(exc.Message);
            }
        }

        public List<Item> GetItems()
        {
            List<Item> itemsList = new List<Item>();
            try
            {
                string sql = "select id, title, price, description, image from items_table";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string title = reader["title"].ToString();
                    double price = double.Parse(reader["price"].ToString());
                    string description = reader["description"].ToString();
                    string image = reader["image"].ToString();
                    itemsList.Add(new Item(id, title, description, image, price));
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            return itemsList;
        }
        public WishList GetWishList(int userID)
        {
            WishList wishList = new WishList();
            List<int> itemIdList = new List<int>();
            try
            {
                string sql = "select itemID from wishlist_table where userID=@userID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userID", userID.ToString());
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int itemID = int.Parse(reader["itemID"].ToString());
                    itemIdList.Add(itemID);
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            wishList = GetWishListItems(itemIdList);
            return wishList;
        }

        private WishList GetWishListItems(List<int> ItemIDList)
        {
            WishList wishList = new WishList();
            List<Item> itemsList = new List<Item>();
            try
            {
                
                foreach (int id in ItemIDList)
                {
                    string sql = "select id, title, price, description, image from items_table where id=@ItemID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ItemID", id);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int ID = int.Parse(reader["id"].ToString());
                        string title = reader["title"].ToString();
                        double price = double.Parse(reader["price"].ToString());
                        string description = reader["description"].ToString();
                        string image = reader["image"].ToString();
                        itemsList.Add(new Item(ID, title, description, image, price));
                    }
                    conn.Close();
                    wishList.SetItems(itemsList);
                }
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            return wishList;
        }

        public List<Category> GetCategories()
        {
            List<Category> categoriesList = new List<Category>();
            try
            {
                string sql = "select id, title from categories_table";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string title = reader["title"].ToString();
                    categoriesList.Add(new Category(id, title));
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }

            foreach (Category category in categoriesList)
                category.SetItems(GetItems(category.Id));
            
            return categoriesList;
        }
        private List<Item> GetItems(int categoryId)
        {
            List<Item> itemsList = new List<Item>();
            try
            {
                string sql = "select id, title, price, description, image from items_table where categoryId=@categoryId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string title = reader["title"].ToString();
                    double price = double.Parse(reader["price"].ToString());
                    string description = reader["description"].ToString();
                    string image = reader["image"].ToString();
                    itemsList.Add(new Item(id, title, description, image, price));
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            return itemsList;
        }
        public void AddNewCategory(string categoryTitle)
        {
            try
            {
                string sql = "insert into categories_table (title) values (@title)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", categoryTitle);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }
        public void AddToWishlist(int itemID, int userID)
        {
            try
            {
                //add check if item is already in wishlist
                string sql = "insert into wishlist_table (itemID, userID) values (@itemID, @userID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }
        public void RemoveFromWishlist(int itemID, int userID)
        {
            try
            {
                string sql = "delete from wishlist_table where itemID=@itemID and userID=@userID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }

        public List<Comment> GetCommentList(int itemID)
        {
            List<Comment> commentList = new List<Comment>();
            try
            {
                string sql = "select item_id, user_id, date, text from comments_table where item_id=@itemID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int userID = int.Parse(reader["user_id"].ToString());
                    string date = reader["date"].ToString();
                    string text = reader["text"].ToString();
                    int itemid = int.Parse(reader["item_id"].ToString());
                    commentList.Add(new Comment(date, text, itemid, userID));
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            return commentList;
        }

        public List<PaymentsLogItem> getPaymentsList()
        {
            List<PaymentsLogItem> paymentsList = new List<PaymentsLogItem>();
            try
            {
                string sql = "select id, date, userID, itemID from payments_table";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string date = reader["date"].ToString();
                    int userID = int.Parse(reader["userID"].ToString());
                    int itemID = int.Parse(reader["itemID"].ToString());
                    paymentsList.Add(new PaymentsLogItem(id, date, userID, itemID));
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            return paymentsList;
        }

        public Item getItemByID(int itemID)
        {
            Item wantedItem = null;
            try
            {
                string sql = "select id, title, price, description, categoryID, image from items_table where id=@itemID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string title = reader["title"].ToString();
                    double price = double.Parse(reader["price"].ToString());
                    string description = reader["description"].ToString();
                    string categoryID = reader["categoryID"].ToString();
                    string image = reader["image"].ToString();
                    wantedItem = new Item(id, title, description,image, price);
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            return wantedItem;
        }

        public List<PaymentsLogItem> getUserBuyHistory(string userID)
        {
            List<PaymentsLogItem> paymentsList = new List<PaymentsLogItem>();
            try
            {
                string sql = "select id, date, userID, itemID from payments_table where userID=@userID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string date = reader["date"].ToString();
                    int usrID = int.Parse(reader["userID"].ToString());
                    int itemID = int.Parse(reader["itemID"].ToString());
                    paymentsList.Add(new PaymentsLogItem(id, date, usrID, itemID));
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            return paymentsList;
        }

        public List<CartItem> getUserCart(string userID)
        {
            List<CartItem> cartItemsList = new List<CartItem>();
            try
            {
                string sql = "select id, itemID from cart_items where userID=@userID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int itemID = int.Parse(reader["itemID"].ToString());
                    cartItemsList.Add(new CartItem(id, itemID));
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            return cartItemsList;
        }

        public void removeFromCart(int itemID, int userID)
        {
            try
            {
                string sql = "delete from cart_items where itemID=@itemID and userID=@userID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }
        public void addToCart(int itemID, int userID)
        {
            try
            {
                string sql = "insert into cart_items (itemID, userID) values (@itemID, @userID)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }

        public void addPurchasesToSql(int itemID, int userID)
        {
            try
            {
                string sql = "insert into payments_table (itemID, userID, date) values (@itemID, @userID, @date)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy/MM/dd"));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }
        public Promotion getPromotion(int userID)
        {
            Promotion promotion = null;
            try
            {
                string sql = "select id, title, active, use_date, userID, value from promotions_offers where userID=@userID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string title = reader["title"].ToString();
                    string active = reader["active"].ToString();
                    string use_date = reader["use_date"].ToString();
                    int usrID = int.Parse(reader["userID"].ToString());
                    int value = int.Parse(reader["value"].ToString());
                    promotion = new Promotion(id, title, active, use_date, usrID, value);
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                conn.Close();
                Debug.WriteLine(exc.Message);
            }
            return promotion;
        }

        public void changeOfferActive(int id)
        {
            try
            {
                string sql = "update promotions_offers set active=@active where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@active", "yes");
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }

        public void deactivatePromotion(int id)
        {
            try
            {
                string sql = "update promotions_offers set active=@active, use_date=@use_date where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@active", "no");
                cmd.Parameters.AddWithValue("@use_date", DateTime.Now.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }

        public void logAction(int userID, int itemID, string action)
        {
            try
            {
                string sql = "insert into log (userID, itemID, date, action) values (@userID, @itemID, @date, @action)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@itemID", itemID);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@action", action);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw new Exception("Error!");
            }
        }

        public void logActionTxt(int userID, int itemID, string action)
        {
            try
            {
                
            }
            catch
            {
                conn.Close();
                throw new Exception("Couldn't log Txt!");
            }
        }
    }
}
