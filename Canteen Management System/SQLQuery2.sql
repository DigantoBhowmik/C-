CREATE TABLE mehe
(
	[Name] VARCHAR(50) NULL, 
    [Price] VARCHAR(50) NULL, 
    [Quantity] INT NOT NULL, 
    [Total_Price] INT NOT NULL, 
    [Dater] VARCHAR(50) NULL, 
    [Id] INT NOT NULL IDENTITY, 
    CONSTRAINT [PK_mehe] PRIMARY KEY ([Id])
)
