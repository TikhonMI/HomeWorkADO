using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //Поставщик данных OleDb (универсальный, но медленный) Лучше использовать под конкретную базу данных
using System.Data.Odbc; //Самый старый поставщик (универсальный, но медленный) если нет OleDb

//Запрос всех БД на сервере
/*Для PostgreSQL: 
SELECT datname FROM pg_database;
  Для SQL Server:
SELECT name FROM sys.databases;
*/

//Запрос всех таблиц в БД
//SELECT* FROM INFORMATION_SCHEMA.TABLES;

/*
 * Этапы:
//---01 Формеруем строку подключения--- 
//-------------------------------------
//___01.1 Для PostgreSQL:___
string connectionString = "Host=localhost; Port=5432; Database=farmers_markets; Server Compatibility Mode=NoTypeLoading; Username=marketsuser; Password=Pa$$W0rd";
//Host-имя хоста
//Port-порт PostgreSQL
//Database-имя БД
//Server Compatibility Mode-
//Username-
//Password-
//! Для работы необходимо поставить пакет (п.к.м на проекте Управление пакетами NuGet...) Npgsql, подключить using Npgsql;
//--------------------------
//___01.2 Для SQL Server:___
string connectionString = "Data Source = (local); Initial Catalog = Northwind; Integrated Security = True";
//или
string connectionString = "Provider=SQLOLEDB.1;Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = Northwind; Data Source = (local)";
//Provider-Поставщик, только для OleDB
//Integrated Security- поддерживается режим Windows аутентификации True или False SSPI=True
//User ID/Password-Параметры пользователя
//Persist Security Info-Заявка на получение информации о защите
//Initial Catalog-Имя БД
//Data Source-Имя сервера

//---02 Подключение (Connection)---
//--------------------------
//___02.1 Для PostgreSQL:___
NpgsqlConnection connection = new NpgsqlConnection(connectionString);
//--------------------------
//___01.2 Для SQL Server:___
OleDbConnection connection = new OleDbConnection(connectionString);

//---03 Открыть подключение (Open) и проверка---
//----------------------------------------------
try
{
    connection.Open();
}
catch (Exception ex)
{
    Console.WriteLine("Failure: " + ex.Massage);
}
finally
{
    if (connection.State != System.Data.ConnectionState.Closed)
    {
        connection.Close();
    }
}

*/

namespace TestingDB
{
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e) //Menu>View>Cascade
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e) //Menu>View>Title
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e) //Menu>DB>Connection
        {

        }
    }
}
