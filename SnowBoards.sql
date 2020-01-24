Create Table Snowboards(
SnowboardsId BigInt Identity(1,1) Primary Key,
Products Varchar(100) Not Null,
Model Varchar(100),
Lenght Int Not Null,
Price Decimal Not Null,
Quantity BigInt Not Null,
CratedDate DateTime Default(GetDate()) Not null)