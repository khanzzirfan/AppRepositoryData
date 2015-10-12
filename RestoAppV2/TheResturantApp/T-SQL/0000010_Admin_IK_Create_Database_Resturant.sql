use [master]
if not exists(select * from sys.databases where name = 'resturant')
    create database resturant
