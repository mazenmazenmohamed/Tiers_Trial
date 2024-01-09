using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class DBManager
    {
        SqlConnection sqlCN;
        SqlCommand sqlCmd;
        SqlDataAdapter DA;
        DataTable DT;
        public DBManager() 
        {
            try
            {
                sqlCN = new SqlConnection();
                sqlCN.ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindCN"].ConnectionString;
                sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = sqlCN;
                DA = new SqlDataAdapter(sqlCmd);
                DT = new DataTable();
                
            }
            
            
            catch { 
                // log Exception
                  }
        
        }  
        //here the fun to excecute the procedure not has a parameters
        public int ExcecuteNonQuery(string spName) 
        {
            int R = -1;
            try 
            {
                if (sqlCN?.State == ConnectionState.Closed)
                {
                    sqlCN.Open();
                    sqlCmd.CommandText = spName;
                    sqlCmd.Parameters.Clear();
                    R = sqlCmd.ExecuteNonQuery();
                    sqlCN.Close();

                }
            }

            catch 
            { 
            
            }
             return R;
        }
        public object ExcecuteScalar(string spName)
        {
            object R = new object();
            try 
            {
                if (sqlCN?.State == ConnectionState.Closed)
                {
                    sqlCN.Open();
                    sqlCmd.CommandText = spName;
                    sqlCmd.Parameters.Clear();
                    R = sqlCmd.ExecuteScalar();
                    sqlCN.Close();
                }
            }
  
            catch
            {

            }
            return R;
        }
        public DataTable ExcecuteDataTable(string spName)
        {
            DT.Clear();
            try 
            {
                sqlCmd.CommandText = spName;
                sqlCmd.Parameters.Clear();
                DA.Fill(DT);
            }
 
            catch 
            { 
            //log Exception Type , Time , message , Stack Trace 
            }
            return DT;
        }
        //here the fun to excecute the procedure  has a parameters
        public int ExcecuteNonQuery(string spName , Dictionary<string, Object> ParamLst)
        {
            int R = -1;
            try
            {
                if ((sqlCN?.State == ConnectionState.Closed)&&(ParamLst?.Count>0))
                {
                    sqlCN.Open();
                    sqlCmd.CommandText = spName;
                    sqlCmd.Parameters.Clear();
                    foreach (KeyValuePair<string, Object> item in ParamLst)
                    { sqlCmd.Parameters.AddWithValue(item.Key, item.Value); }
                    R = sqlCmd.ExecuteNonQuery();
                    sqlCN.Close();

                }
            }

            catch
            {

            }
            return R;
        }
        public object ExcecuteScalar(string spName , Dictionary<string,Object> ParamLst)
        {
           throw new NotImplementedException();
        }
        public DataTable ExcecuteDataTable(string spName, Dictionary<string, Object> ParamLst)
        {
            throw new NotImplementedException();
        }
    }
}
