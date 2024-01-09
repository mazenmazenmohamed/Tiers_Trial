create procedure InsertProduct 
(
            @productID int , 
            @productName varchar(45) ,
            @supplierID int null,
            @categoryID int null,
            @quantityPerUnit varchar(20) null,
            @unitPrice Money null,
            @unitsInStocks smallint null ,
            @unitsInOrder smallint null,
            @reorderLevel smallint null,
            @discontinued bit null
            )as 
begin
insert into Product values
(
            @productID, 
            @productName ,
            @supplierID ,
            @categoryID ,
            @quantityPerUnit,
            @unitPrice ,
            @unitsInStocks,
            @unitsInOrder,
            @reorderLevel ,
            @discontinued 
            );
end;
exec InsertProduct
@productID=21,
@productName='pepsi',
@supplierID=1,
@categoryID=1,
@quantityPerUnit='h',
@unitPrice=10.0,
@unitsInStocks=10,
@unitsInOrder=20,
@reorderLevel=30,
@discontinued=1;
--insert into Product values (21,'pepsi',1,1,'h',10.0,10,20,30,1);
EXEC SelectAllProducts;
--EXEC DeleteProductByID @ID =1;



