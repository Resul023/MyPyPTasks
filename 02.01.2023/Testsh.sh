#!/bin/bash
folder_Name="Tasksh"
mkdir $folder_Name
cd $folder_Name
dotnet new sln
dotnet new mvc -o $folder_Name
dotnet sln add $folder_Name
cd $folder_Name
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
cd Models	
touch Product.cs
touch Category.cs
echo "namespace $folder_Name.Models;
public class Product
{
    public int ProductId { get; set; }

    
}" > Product.cs
echo "namespace $folder_Name.Models;
public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int Description { get; set; }

    
}" > Category.cs