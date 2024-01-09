using BusineesLogicLayer.Entities;
using BusineesLogicLayer.EntityLists;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;


namespace BusineesLogicLayer.EntityManagers
{
    public class ProductManager
    {
        static DBManager dBManager = new DBManager();
        public static ProductList SelectAllProducts()
        {
            try 
            {
               

                return DataTableToProductList(
                dBManager.ExcecuteDataTable("SelectAllProducts")
               );
            }
  
            catch{
            //logException
            }
            
            return new ProductList();
            
        }
        public static bool DeleteProductByID(int productID)
        {
            try
            {
                Dictionary<string,Object>ParamLst= new Dictionary<string, Object>()
                { ["@ID"] = productID };
                if (dBManager.ExcecuteNonQuery("DeleteProductByID", ParamLst) > 0)
                    return true;
              
                
               
            }

            catch
            {
                //logException
            }

            return false;

        }
        public static bool InsertProduct(
            int productID, 
            string productName,
            Nullable<int> supplierID,
            Nullable<int> categoryID,
            string quantityPerUnit,
            decimal? unitPrice,
            short? unitsInStocks,
            short? unitsInOrder,
            short? reorderLevel,
            bool discontinued
            )
        {
            try
            {
                Dictionary<string, Object> ParamLst = new Dictionary<string, Object>()
                {
                    ["@productId"] = productID,
                    ["@productName"] =  productName,
                    ["@supplierID"] = supplierID,
                    ["@categoryID"] = categoryID,
                    ["@quantityPerUnit"] = quantityPerUnit,
                    ["@unitPrice"] = unitPrice,
                    ["@unitsInStocks"] = unitsInStocks,
                    ["@unitsInOrder"] = unitsInOrder,
                    ["@reorderLevel"] = reorderLevel,
                    ["@discontinued"] = discontinued
                };
                if (dBManager.ExcecuteNonQuery("InsertProduct", ParamLst) > 0)
                    return true;
            }
            catch
            {
                //logException
            }
            return false;
        }
        internal static ProductList DataTableToProductList(DataTable DT)
        {
            ProductList PrdList = new ProductList();
            try 
            {
                
                if (DT?.Rows?.Count > 0)
                {
                    foreach (DataRow dr in DT.Rows)
                    {
                        PrdList.Add(DataRowToProduct(dr));
                    }
                }
            }
            
         
            catch 
            {
            //log Exception
            }
            return PrdList;
        }

        internal static Product DataRowToProduct(DataRow DR) 
        {
            int TempInt;
            short TempShort;
            Product Prd = new Product();
            try 
            {
                
                Prd.ProductID = DR.Field<int>("ProductID");
                Prd.ProductName = DR.Field<string>("ProductName")?.ToString() ?? "NAN";
                Prd.QuantityPerUnit = DR.Field<string>("QuantityPerUnit")?.ToString() ?? "NAN";

                if (int.TryParse(DR["CategoryID"]?.ToString() ?? "0", out TempInt))
                {
                    Prd.CategoryID = TempInt;
                }
                if (int.TryParse(DR["SupplierID"]?.ToString() ?? "0", out TempInt))
                {
                    Prd.SupplierID = TempInt;
                }
                if (decimal.TryParse(DR["UnitPrice"]?.ToString() ?? "0", out decimal TempDecimal))
                {
                    Prd.UnitPrice = TempDecimal;
                }
                if (short.TryParse(DR["UnitsInStocks"]?.ToString() ?? "0", out TempShort))
                {
                    Prd.UnitsInStocks = TempShort;
                }
                if (short.TryParse(DR["UnitsInOrder"]?.ToString() ?? "0", out TempShort))
                {
                    Prd.UnitsInOrder = TempShort;
                }
                if (short.TryParse(DR["ReorderLevel"]?.ToString() ?? "0", out TempShort))
                {
                    Prd.ReorderLevel = TempShort;
                }
                if (bool.TryParse(DR["Discontinued"]?.ToString() ?? "False", out bool TempBool))
                {
                    Prd.Discontinued = TempBool;
                }

                Prd.State = EntityState.UnChanged;
            }



            catch { }
            return Prd;
        }

    }
}
