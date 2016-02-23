import sys
import sqlite3

from sales import load_sales_data
from catalog import load_catalog_by_item_id

def main():
    if len(sys.argv) < 4:
        print("Usage: {} <catalog-file.csv> <sales-file.csv> <output.db>".format(sys.argv[0]))
        return 2

    # TODO: check if files exist and are readable

    catalog_by_item_id = load_catalog_by_item_id(sys.argv[1])
    sales = load_sales_data(sys.argv[2])

    db_filename = sys.argv[3]

    with sqlite3.connect(db_filename, isolation_level=None) as connection:
        print("Connection opened")
        create_tables(connection)
        print("Tables created")
        import_catalog_into_db(catalog_by_item_id, connection)
        print("Catalog imported")
        import_sales_into_db(sales, connection)

def create_tables(connection):
    cursor = connection.cursor()
    cursor.execute("""
        create table if not exists sale (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            catalog_id INTEGER NOT NULL,
            country varchar(3),
            city_name varchar(60),
            sale_timestamp TEXT,
            price NUMERIC,
            foreign key (catalog_id) references catalog (id)
        );
    """)

    cursor.execute("""
        create table if not exists catalog (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            item_key varchar(200) UNIQUE,
            category varchar(200)
        );
    """)

def import_catalog_into_db(catalog_by_item_id, connection):
    cursor = connection.cursor()
    for catalog_entry in catalog_by_item_id.values():
        cursor.execute(
            "insert into catalog (item_key, category) values (?, ?)",
            [catalog_entry.item_id, catalog_entry.category_name]
        )

def import_sales_into_db(sales, connection):
    cursor = connection.cursor()
    for sale in sales:
        cursor.execute(
            """
            insert into sale
                (item_key, country, city_name, sale_timestamp,price)
            values
                (?, ?, ?, ?, ?)
            """,
            [sale.item_id, sale.country, sale.city, sale.sale_timestamp, float(sale.price)]
        )
        pass

if __name__ == '__main__':
    main()