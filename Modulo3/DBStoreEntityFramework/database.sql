CREATE TABLE "Categories" (
    "CategoryID" SERIAL PRIMARY KEY,
    "CategoryName" VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE "Products" (
    "ProductID" SERIAL PRIMARY KEY,
    "CategoryID" INT NOT NULL REFERENCES "Categories"("CategoryID") ON DELETE CASCADE,
    "ProductName" VARCHAR(100) NOT NULL,
    "Price" NUMERIC(10,2) NOT NULL CHECK ("Price" >= 0),
    "Stock" INT NOT NULL CHECK ("Stock" >= 0)
);

CREATE TABLE "Sales" (
    "SaleID" SERIAL PRIMARY KEY,
    "SaleDate" TIMESTAMP NOT NULL DEFAULT NOW(),
    "Total" NUMERIC(10,2) NOT NULL CHECK ("Total" >= 0)
);

CREATE TABLE "SaleDetails" (
    "SaleDetailID" SERIAL PRIMARY KEY,
    "SaleID" INT NOT NULL REFERENCES "Sales"("SaleID") ON DELETE CASCADE,
    "ProductID" INT NOT NULL REFERENCES "Products"("ProductID") ON DELETE RESTRICT,
    "Quantity" INT NOT NULL CHECK ("Quantity" > 0),
    "UnitPrice" NUMERIC(10,2) NOT NULL CHECK ("UnitPrice" >= 0),
    "Subtotal" NUMERIC(10,2) NOT NULL CHECK ("Subtotal" >= 0)
);
