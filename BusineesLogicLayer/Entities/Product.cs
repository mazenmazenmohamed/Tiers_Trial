using System;
namespace BusineesLogicLayer.Entities
{
    public class Product:EntityBase
    {
        int productID;
        public int ProductID {
            get=> productID; 
            set 
            {
               
                    if (productID != value)
                    {
                         productID = value;
                        if (State != EntityState.Added)
                            this.State = EntityState.Modified;
                    }

                }
            
        }
        
        string productName;
        public string ProductName 
        { 
            get => productName;
            set 
            { 
                if (productName != value) 
                {
                    productName = value; 
                    if(State!=EntityState.Added)
                    this.State = EntityState.Modified;
                }
                
            }
        }

        Nullable<int> supplierID;
        public Nullable<int> SupplierID 
        {
            get=> supplierID;
            set
            {
                if (supplierID != value)
                {
                    supplierID = value;
                    if (State != EntityState.Added)
                        this.State = EntityState.Modified;
                }

            }
        }

        Nullable<int> categoryID;
        public Nullable<int> CategoryID 
        { 
            get=> categoryID;
            set
            {
                if (categoryID != value)
                {
                    categoryID = value;
                    if (State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }

        string quantityPerUnit;
        public string QuantityPerUnit {
            get=> quantityPerUnit;
            set 
            {
                if (quantityPerUnit != value)
                {
                    quantityPerUnit = value;
                    if (State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            } 
        }

        decimal? unitPrice;
        public decimal? UnitPrice 
        { get => unitPrice;
          set 
          {
                if (unitPrice != value)
                {
                    unitPrice = value;
                    if (State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }

        short? unitsInStocks;
        public short? UnitsInStocks 
        { get => unitsInStocks;
            set 
            {
                if (unitsInStocks != value)
                {
                    unitsInStocks = value;
                    if (State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            }
        }
        short? unitsInOrder;
        public short? UnitsInOrder 
        {
            get => unitsInOrder;
            set 
            {
                if (unitsInOrder != value)
                {
                    unitsInOrder = value;
                    if (State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            } 
        }

        short? reorderLevel;
        public short? ReorderLevel 
        { 
            get => reorderLevel; 
            set 
            {
                if (reorderLevel != value)
                {
                    reorderLevel = value;
                    if (State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            } 
        }

        bool discontinued;
        public bool Discontinued 
        { 
            get => discontinued; 
            set 
            {
                if (discontinued != value)
                {
                    discontinued = value;
                    if (State != EntityState.Added)
                        this.State = EntityState.Modified;
                }
            } 
        }
    }
}
