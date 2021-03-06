﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SR.Service
{
    public class OrderService
    {
        MySqlConnection connection;
        string MyConnectionString = "Server=localhost;Database=SR_database;Uid=root;Pwd='';Charset=utf8";

        public string orderquery { get; set; }

        public OrderService()
        {
            connection = new MySqlConnection(MyConnectionString);

        }

        //CREATE NEW ORDER
        public void CreateNewOrder(string model_name,
                                     string client_name,
                                     string city,
                                     string school,
                                     string phone,
                                     string test_date,
                                     string weding_date,
                                     string chest_lap,
                                     string podgradna_lap,
                                     string waist_measurement,
                                     string low_waist,
                                     string lap_hips,
                                     string skirt_lenght_front,
                                     string skirt_lenght_back,
                                     string sleeve_length,
                                     string tour_biceps,
                                     string length_from_shoulder_to_tq,
                                     string length_from_7shp_to_waist,
                                     string length_from_7shp_to_floor,
                                     string line_of_skirt_attachment,
                                     string place_of_skirt_attachment,
                                     string princess_number_of_skirts,
                                     string italian_tulle,
                                     string crystal_tulle,
                                     string price,
                                     string deposit,
                                     string technical_description,

                                     string cutoutdress_worker_id,
                                     string made_by_worker_id
            )
        {

            connection.Open();

            string createQuery = "INSERT INTO orders " +
                        "(" +
                            "model_name, " +
                            "client_name, " +
                            "city, " +
                            "school, " +
                            "phone, " +
                            "test_date, " +
                            "weding_date, " +
                            "chest_lap, " +
                            "podgradna_lap, " +
                            "waist_measurement, " +
                            "low_waist, " +
                            "lap_hips, " +
                            "skirt_lenght_front, " +
                            "skirt_lenght_back, " +
                            "sleeve_length, " +
                            "tour_biceps, " +
                            "length_from_shoulder_to_tq, " +
                            "length_from_7shp_to_waist, " +
                            "length_from_7shp_to_floor, " +
                            "line_of_skirt_attachment, " +
                            "place_of_skirt_attachment, " +
                            "princess_number_of_skirts, " +
                            "italian_tulle, " +
                            "crystal_tulle, " +
                            "price, " +
                            "deposit, " +
                            "technical_description, " +
                            


                            "cutoutdress_worker_id, " +
                            "made_by_worker_id " +

                        ") " +
                        "VALUES " +
                        "(" +
                        $"'{model_name}', " +
                        $"'{client_name}', " +
                        $"'{city}', " +
                        $"'{school}', " +
                        $"'{phone}', " +
                        $"'{test_date}', " +
                        $"'{weding_date}', " +
                        $"'{chest_lap}', " +
                        $"'{podgradna_lap}', " +
                        $"'{waist_measurement}', " +
                        $"'{low_waist}', " +
                        $"'{lap_hips}', " +
                        $"'{skirt_lenght_front}', " +
                        $"'{skirt_lenght_back}', " +
                        $"'{sleeve_length}', " +
                        $"'{tour_biceps}', " +
                        $"'{length_from_shoulder_to_tq}', " +
                        $"'{length_from_7shp_to_waist}', " +
                        $"'{length_from_7shp_to_floor}', " +
                        $"'{line_of_skirt_attachment}', " +
                        $"'{place_of_skirt_attachment}', " +
                        $"'{princess_number_of_skirts}', " +
                        $"'{italian_tulle}', " +
                        $"'{crystal_tulle}', " +
                        $"'{price}', " +
                        $"'{deposit}', " +
                        $"'{technical_description}', " +

                        $"'{cutoutdress_worker_id}', " +
                        $"'{made_by_worker_id}' " +
                         ")";



            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand(createQuery, connection);
                cmd.ExecuteNonQuery();
            }
        }


        //GET ALL CLIENT NAMES FOR AUTOCOMPLETE
        public string[] GetAllClientNames()
        {
            
            string query = "SELECT  o.client_name " +
              "FROM orders AS o " +
              "ORDER BY o.client_name";

            connection.Open();

            List<string> clientNamesList = new List<string>();

            using (connection)
            {
                MySqlCommand command1 = new MySqlCommand(query, connection);
                MySqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {

                    clientNamesList.Add(reader[0].ToString());
                }

            }

            return clientNamesList.ToArray();

        }

        //GET ALL PHONES FOR AUTOCOMPLETE
        public string[] GetAllPhoneNumbers()
        {

            string query = "SELECT  o.phone " +
              "FROM orders AS o ";

            connection.Open();

            List<string> phoneNumbersList = new List<string>();

            using (connection)
            {
                MySqlCommand command1 = new MySqlCommand(query, connection);
                MySqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {

                    phoneNumbersList.Add(reader[0].ToString());
                }

            }

            return phoneNumbersList.ToArray();

        }



        //CHECK IF DATE IS VALID
        public bool CheckIfDateIsValid(string text)
        {
            string pattern = @"([\d]+)";


            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            List<string> dateList = new List<string>();

            foreach (Match match in matches)
            {
                string first = match.Groups[1].ToString();
                dateList.Add(first);
            }

            if (dateList.Count != 3)
            {
                return true;
            }
            else
            {
                if (dateList[2].Length > 2 || int.Parse(dateList[2]) > 31 ||
                    dateList[1].Length > 2 || int.Parse(dateList[1]) > 12 ||
                    dateList[0].Length != 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }


        //CONVERT TO DATETIME
        public string ConverteToDate(string text)
        {
            string pattern = @"([\d]+)";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            List<string> dateList = new List<string>();

            foreach (Match match in matches)
            {
                string first = match.Groups[1].ToString();
                dateList.Add(first);
            }

            string dateString = $"{dateList[0]}-{dateList[1]}-{dateList[2]}";

            return dateString;
        }

        //CREATE NEW MANIPULATION
        public void createNewManipulation(string orderNumber, string worker_id, string manipDescription, string manipulation_date, int timeNeeded, int amount, int category)
        {
            connection.Open();


            string createQuery = "INSERT INTO manipulations " +
                        "(" +
                            "description, " +
                            "manipulation_date, " +
                            "time_needed, " +
                            "amount, " +
                            "category, " +
                            "worker_id, " +
                            "order_id " +
                        ") " +
                        "VALUES " +
                        "(" +
                        $"'{manipDescription}', " +
                        $"'{manipulation_date}', " +
                        $"'{timeNeeded}', " +
                        $"'{amount}', " +
                        $"'{category}', " +
                        $"'{worker_id}', " +
                        $"'{orderNumber}' " +
                         ")";


            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand(createQuery, connection);
                cmd.ExecuteNonQuery();
            }

        }

        //CHECK IF THE INPUT IS INTEGER
        public bool CheckIfIsInteger(string text)
        {
            string pattern = @"^\d+$";
            Regex regex = new Regex(pattern);

            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            else
            {
                return regex.IsMatch(text);

            }
        }



        //------UPDATE CURRENT ORDER
        public void UpdateCurrentOrder(string orderNumber,
                                             string model_name,
                                             string client_name,
                                             string city,
                                             string school,
                                             string phone,
                                             //TODO 
                                             // update date
                                             string chest_lap,
                                             string podgradna_lap,
                                             string waist_measurement,
                                             string low_waist,
                                             string lap_hips,
                                             string skirt_lenght_front,
                                             string skirt_lenght_back,
                                             string sleeve_length,
                                             string tour_biceps,
                                             string length_from_shoulder_to_tq,
                                             string length_from_7shp_to_waist,
                                             string length_from_7shp_to_floor,
                                             string line_of_skirt_attachment,
                                             string place_of_skirt_attachment,
                                             string princess_number_of_skirts,
                                             string italian_tulle,
                                             string crystal_tulle,
                                             string technical_description,


                                             string cutoutdress_worker_id,
                                             string made_by_worker_id)
        {
            connection.Open();

            string createQuery = "UPDATE orders " +
                             "SET " +
                            $"model_name='{model_name}', " +
                            $"client_name='{client_name}', " +
                            $"city='{city}', " +
                            $"school='{school}', " +
                            $"phone='{phone}', " +
                            $"chest_lap='{chest_lap}', " +
                            $"podgradna_lap='{podgradna_lap}', " +
                            $"waist_measurement='{waist_measurement}', " +
                            $"low_waist='{low_waist}', " +
                            $"lap_hips='{lap_hips}', " +
                            $"skirt_lenght_front='{skirt_lenght_front}', " +
                            $"skirt_lenght_back='{skirt_lenght_back}', " +
                            $"sleeve_length='{sleeve_length}', " +
                            $"tour_biceps='{tour_biceps}', " +
                            $"length_from_shoulder_to_tq='{length_from_shoulder_to_tq}', " +
                            $"length_from_7shp_to_waist='{length_from_7shp_to_waist}', " +
                            $"length_from_7shp_to_floor='{length_from_7shp_to_floor}', " +
                            $"line_of_skirt_attachment='{line_of_skirt_attachment}', " +
                            $"place_of_skirt_attachment='{place_of_skirt_attachment}', " +
                            $"princess_number_of_skirts='{princess_number_of_skirts}', " +
                            $"italian_tulle='{italian_tulle}', " +
                            $"crystal_tulle='{crystal_tulle}', " +
                            $"technical_description='{technical_description}', " +



                            $"cutoutdress_worker_id='{cutoutdress_worker_id}', " +
                            $"made_by_worker_id='{made_by_worker_id}' " +


                            $"WHERE order_id = '{orderNumber}'";


            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand(createQuery, connection);
                cmd.ExecuteNonQuery();
            }
        }

        //GET CURRENT MANIPULATIONS
        public string GetCurrentManipulations(string orderNumber)
        {
            return "SELECT m.maniulation_id AS 'Номер',  m.category AS 'Категория'," +
                "w.worker_name AS 'Работник', m.description AS 'Описание', m.manipulation_date AS 'Дата', " +
                "m.amount AS 'Брой', m.time_needed AS 'Време' " +
                 $"FROM manipulations AS m " +
                 "INNER JOIN workers as w " +
                 "ON m.worker_id = w.worker_id " +
                 $"WHERE m.order_id = '{orderNumber}' ";

        }

        public string selectOnlyWorkerName()
        {
            return "SELECT worker_name FROM workers";
        }
        public string GetAllWorkers()
        {
            return "SELECT * FROM workers";
        }


        public int GetWorkerId(string worker)
        {
            string createQuery = $"SELECT worker_id FROM workers WHERE worker_name ='{worker}'";
            int result = 0;

            connection.Open();
            using (connection)
            {
                MySqlCommand cmd = new MySqlCommand(createQuery, connection);
                result = (int)cmd.ExecuteScalar();

            }
            return result;
        }


        public string GetAllOrders()
        {
            return "SELECT o.order_id AS 'Номер на поръчката', o.model_name AS 'Име на модел', o.client_name AS 'Име на клиент', " +
                "o.city AS 'Град', o.phone AS 'Телефон', o.weding_date AS 'Дата на Сватбата'," +
                "w.worker_name AS 'Изработва'" +
                "FROM orders AS o " +
                "INNER JOIN workers as w " +
                "ON o.made_by_worker_id = w.worker_id " +
                "ORDER BY o.order_id DESC";
        }

        public string GetOrdersByClientName(string clientName)
        {

            return "SELECT o.order_id AS 'Номер на поръчката', o.model_name AS 'Име на модел', o.client_name AS 'Име на клиент', " +
                 "o.city AS 'Град', o.phone AS 'Телефон', o.weding_date AS 'Дата на Сватбата'," +
                 "w.worker_name AS 'Изработва'" +
                 "FROM orders AS o " +
                 "INNER JOIN workers as w " +
                 "ON o.made_by_worker_id = w.worker_id " +
                 $"WHERE o.client_name LIKE '%{clientName}%' " +
                 "ORDER BY o.order_id DESC";
        }
        public string GetOrdersByPhoneNumber(string phoneNumber)
        {

            return "SELECT o.order_id AS 'Номер на поръчката', o.model_name AS 'Име на модел', o.client_name AS 'Име на клиент', " +
                 "o.city AS 'Град', o.phone AS 'Телефон', o.weding_date AS 'Дата на Сватбата'," +
                 "w.worker_name AS 'Изработва'" +
                 "FROM orders AS o " +
                 "INNER JOIN workers as w " +
                 "ON o.made_by_worker_id = w.worker_id " +
                 $"WHERE o.phone LIKE '%{phoneNumber}%' " +
                 "ORDER BY o.order_id DESC";
        }

        

        public string GetCurrentOrderQuery(string orderNum)
        {
            return $"SELECT * FROM orders WHERE order_id = '{orderNum}'";
        }


        //CHECK IF ORDER EXISTS
        public bool CheckIfOrderExists(int orderNum)
        {
            string createQuery = $"SELECT * FROM orders WHERE order_id ='{orderNum}'";
            int result = 0;

            connection.Open();
            using (connection)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(createQuery, connection);
                    result = (int)cmd.ExecuteScalar();
                }
                catch (Exception)
                {

                }
            }

            if (result == 0)
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
