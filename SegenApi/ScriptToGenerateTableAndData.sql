if OBJECT_ID(N'dbo.Items') is not null
begin
	drop table Items
end

CREATE TABLE [dbo].[Items](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO






-- Check if #TempItems already exists then drop and create
Set NoCount on;
if OBJECT_ID(N'tempdb..#TempItems') is not null
begin
 drop table #TempItems
end

-- Generate a temporary table with 50 random items
select x.Id,x.Name,x.[Description],
		(CAST(x.Price AS DECIMAL(18, 2)) + (0.1 * (x.row_num - 1))) as Price,
		x.CreatedAt,
		x.ModifiedAt
	INTO #TempItems
 from (
SELECT
    NEWID() AS Id,
    'Item ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS NVARCHAR(255)) AS Name,
    'Description ' + CAST(ABS(CHECKSUM(NEWID())) AS NVARCHAR(255)) AS Description,
    CAST((RAND() * 100) AS DECIMAL(18, 2)) AS Price,
    DATEADD(day, -FLOOR(RAND() * 365), GETDATE()) AS CreatedAt,
    GETDATE() AS ModifiedAt,
    row_num=ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) 
    FROM sys.all_objects
)x
WHERE row_num <= 50;

-- Insert the 50 random items into the Items table
 INSERT INTO Items (Id, Name, Description, Price, CreatedAt, ModifiedAt)
 SELECT Id, Name, Description, Price, CreatedAt, ModifiedAt
 FROM #TempItems;