﻿USE DBContact
GO
CREATE TABLE TBL_Categories (
	PK_Categorie UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(),
	Intitule NVARCHAR(100) NOT NULL,
)


GO
ALTER TABLE TBL_Contacts ADD FK_Categorie UNIQUEIDENTIFIER NULL 

ALTER TABLE TBL_Contacts ADD CONSTRAINT Tbl_Contacts_Categorie
	FOREIGN KEY (FK_Categorie) REFERENCES TBL_Categories(PK_Categorie)