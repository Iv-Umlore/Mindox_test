/*  Очевидно, что в случае когда одному продукту соответствует неколько категорий и наоборот,
 одной категории несколько продуктов, используется вспомогательная таблица.
  Кратко задам эти таблицы простыми скриптами:

CREATE TABLE IF NOT EXISTS base.products (
		ID INT IDENTITY(1,1) PRIMARY KEY,
		Name VARCHAR(50)
	);
	
END;

CREATE TABLE IF NOT EXISTS base.categories (
		ID INT IDENTITY(1,1) PRIMARY KEY,
		Name VARCHAR(50)
	);

CREATE TABLE IF NOT EXISTS base.prod_category (
		product_id INT,
		category_id INT,
		CONSTRAINT FK_Product FOREIGN KEY (product_id) REFERENCES base.products(ID),
		CONSTRAINT FK_Category FOREIGN KEY (category_id) REFERENCES base.categories(ID)
	);

*/

-- Итоговый скрипт будет выглядеть таким образом:

SELECT prod.Name, cat.Name FROM base.products as prod
LEFT JOIN base.prod_category as Link 
ON prod.ID = base.prod_category.product_id
LEFT JOIN base.categories as cat
ON cat.ID = base.prod_category.category_id;