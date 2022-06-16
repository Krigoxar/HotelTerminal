using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using praktika.Model;

namespace praktika.Controller
{
    internal class Db_controller
    {
        internal Db_controller()
        {
            sQLiteConnection = new SQLiteConnection(ConnectionString);
            sQLiteConnection.Open();
        }

        private readonly string ConnectionString = @"Data Source=Model\testDB.db";
        private readonly SQLiteConnection sQLiteConnection;

        internal void AddBookingDetails(Model.booking_wrnt_details_Model bookingDetails, int roomNumber)
        {
            string sqlExpression = "INSERT INTO checkInOutData(userId, checkInDate, checkOutDate, roomType, roomNumber) VALUES(@userId, @checkInDate, @checkOutDate, @roomType, @roomNumber)";
            var writher = new SQLiteCommand(sqlExpression, sQLiteConnection);
            writher.Parameters.AddWithValue("@userId", bookingDetails.userId);
            writher.Parameters.AddWithValue("@checkInDate", bookingDetails.checkInDate);
            writher.Parameters.AddWithValue("@checkOutDate", bookingDetails.checkOutDate);
            writher.Parameters.AddWithValue("@roomType", bookingDetails.roomType);
            writher.Parameters.AddWithValue("@roomNumber", roomNumber);
            writher.ExecuteNonQuery();
        }

        internal void DeleteUserWithId(int id)
        {
            string commandText = "DELETE FROM Users WHERE Id = @Id";
            SQLiteCommand Deleter = new SQLiteCommand(commandText, sQLiteConnection);
            Deleter.Parameters.AddWithValue("@Id", id);
            Deleter.ExecuteNonQuery();
        }

        internal List<booking_wred_details_Model> GetBookingsWithUserId(int id)
        {
            List<Model.booking_wred_details_Model> res = new List<Model.booking_wred_details_Model>();
            string sqlExpression = "SELECT * FROM checkInOutData WHERE userid = @id;";
            SQLiteCommand findCommand = new SQLiteCommand(sqlExpression, sQLiteConnection);
            findCommand.Parameters.AddWithValue("@id", id);
            using (SQLiteDataReader dataReader = findCommand.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Model.booking_wred_details_Model booking_Wred_Details = new Model.booking_wred_details_Model(
                            dataReader.GetInt32(0),
                            dataReader.GetInt32(1),
                            dataReader.GetDateTime(2),
                            dataReader.GetDateTime(3),
                            dataReader.GetString(4),
                            dataReader.GetInt32(5));
                        res.Add(booking_Wred_Details);
                    }
                }
            }
            return res;
        }

        internal void DeleteBookingWithID(int id)
        {
            string commandText = "DELETE FROM checkInOutData WHERE Id = @Id";
            SQLiteCommand Deleter = new SQLiteCommand(commandText, sQLiteConnection);
            Deleter.Parameters.AddWithValue("@Id", id);
            Deleter.ExecuteNonQuery();
        }

        internal int HowManyRoomsISAvilible(string roomType, DateTime dateTime)
        {
            List<Model.booking_wred_details_Model> booking_Wred_DetailsList = new List<Model.booking_wred_details_Model>();
            string sqlExpression = "SELECT * FROM checkInOutData WHERE roomType = @roomType;";
            //string sqlExpression = "SELECT * FROM checkInOutData";
            SQLiteCommand findCommand = new SQLiteCommand(sqlExpression, sQLiteConnection);
            findCommand.Parameters.AddWithValue("@roomType", roomType);
            using (SQLiteDataReader dataReader = findCommand.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Model.booking_wred_details_Model booking_Wred_Details = new Model.booking_wred_details_Model(
                            dataReader.GetInt32(0),
                            dataReader.GetInt32(1),
                            dataReader.GetDateTime(2),
                            dataReader.GetDateTime(3),
                            dataReader.GetString(4),
                            dataReader.GetInt32(5));
                        if (booking_Wred_Details.checkInDate <= dateTime && dateTime <= booking_Wred_Details.checkOutDate)
                        {
                            booking_Wred_DetailsList.Add(booking_Wred_Details);
                        }
                    }
                }
            }
            return Model.MainWindow_Model.MaxRoomsАmount[roomType] - booking_Wred_DetailsList.Count;
        }
        internal List<Model.booking_wred_details_Model> GetWredBookingModels()
        {
            List<Model.booking_wred_details_Model> res = new List<Model.booking_wred_details_Model>();
            string sqlExpression = "SELECT * FROM checkInOutData";
            SQLiteCommand findCommand = new SQLiteCommand(sqlExpression, sQLiteConnection);
            using (SQLiteDataReader dataReader = findCommand.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Model.booking_wred_details_Model booking_Wred_Details = new Model.booking_wred_details_Model(
                            dataReader.GetInt32(0),
                            dataReader.GetInt32(1),
                            dataReader.GetDateTime(2),
                            dataReader.GetDateTime(3),
                            dataReader.GetString(4),
                            dataReader.GetInt32(5));
                        res.Add(booking_Wred_Details);
                    }
                }
            }
            return res;
        }
        internal List<Model.User_Auted_Model> GetUser_Auted_Models()
        {
            List<Model.User_Auted_Model> res = new List<Model.User_Auted_Model>();
            string sqlExpression = "SELECT * FROM Users;";
            SQLiteCommand command = new SQLiteCommand(sqlExpression, sQLiteConnection);
            using (SQLiteDataReader dataReader = command.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        res.Add(new Model.User_Auted_Model(
                            new Model.User_Autnt_Model(dataReader.GetString(1),dataReader.GetString(2)),
                            dataReader.GetInt32(0),
                            dataReader.GetBoolean(3)));
                    }
                }
                else
                {
                    return null;
                }
            }
            return res;
        }
        internal int FindFreeRoom(Model.booking_wrnt_details_Model booking_Wrnt_Details, string roomType)
        {
            List<Model.booking_wred_details_Model> booking_Wred_DetailsList = new List<Model.booking_wred_details_Model>();
            string sqlExpression = "SELECT * FROM checkInOutData WHERE roomType = @roomType;";
            //string sqlExpression = "SELECT * FROM checkInOutData";
            SQLiteCommand findCommand = new SQLiteCommand(sqlExpression, sQLiteConnection);
            findCommand.Parameters.AddWithValue("@roomType", roomType);
            using (SQLiteDataReader dataReader = findCommand.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        booking_Wred_DetailsList.Add(new Model.booking_wred_details_Model(
                            dataReader.GetInt32(0),
                            dataReader.GetInt32(1),
                            dataReader.GetDateTime(2),
                            dataReader.GetDateTime(3),
                            dataReader.GetString(4),
                            dataReader.GetInt32(5)));
                    }
                }
            }
            bool isfound;
            for (int roomNumber = 1; roomNumber-1 < Model.MainWindow_Model.MaxRoomsАmount[booking_Wrnt_Details.roomType];roomNumber++)
            {
                isfound = true;
                foreach (Model.booking_wred_details_Model bookingDetails in booking_Wred_DetailsList)
                {
                    if(!(bookingDetails.RoomNumber == roomNumber
                        &&((booking_Wrnt_Details.checkOutDate < bookingDetails.checkInDate && booking_Wrnt_Details.checkInDate < bookingDetails.checkInDate)
                        ||(bookingDetails.checkOutDate < booking_Wrnt_Details.checkInDate && bookingDetails.checkOutDate < booking_Wrnt_Details.checkOutDate))
                        || bookingDetails.RoomNumber != roomNumber))
                    {
                        isfound = false;
                    }
                }
                if(isfound)
                {
                    return roomNumber;
                }
            }
            return 0;
        }
        internal void CleanBookingDetailsDb()
        {
            List<int> idsList = new List<int>();
            string sqlExpression = "SELECT * FROM checkInOutData;";
            SQLiteCommand findCommand = new SQLiteCommand(sqlExpression, sQLiteConnection);
            using (SQLiteDataReader dataReader = findCommand.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        if(dataReader.GetDateTime(3) < DateTime.Now)
                        {
                            idsList.Add(dataReader.GetInt32(0));
                        }
                    }
                }
            }
            string commandText = "DELETE FROM checkInOutData WHERE Id = @Id";
            foreach(int Id in idsList)
            {
                var deleteCommand = new SQLiteCommand(commandText, sQLiteConnection);
                deleteCommand.Parameters.AddWithValue("@Id", Id);
                deleteCommand.ExecuteNonQuery();
            }
        }
        //Этот метод используется для авторизации пользователя и проверки админ ли он.
        internal Model.User_Auted_Model CheсkUser(Model.User_Autnt_Model user)
        {
            string sqlExpression = "SELECT * FROM Users WHERE login = @login AND password = @password;";
            SQLiteCommand command = new SQLiteCommand(sqlExpression, sQLiteConnection);
            command.Parameters.AddWithValue("@login", user.login);
            command.Parameters.AddWithValue("@password", user.password);
            using (SQLiteDataReader dataReader = command.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return new Model.User_Auted_Model(user, dataReader.GetInt32(0), dataReader.GetBoolean(3));
                }
                return null;
            }
        }
        //Этот метод используется для добавления нового пользователя
        internal bool AddUser(Model.User_Autnt_Model user)
        {
            string sqlExpression = "INSERT INTO Users(login, password) VALUES(@login, @password)";
            var writher = new SQLiteCommand(sqlExpression, sQLiteConnection);
            writher.Parameters.AddWithValue("@login", user.login);
            writher.Parameters.AddWithValue("@password", user.password);
            if(writher.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ~Db_controller()
        {
            //sQLiteConnection.Close();
        }
    }
}
