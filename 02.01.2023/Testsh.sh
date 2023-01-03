#!/bin/bash
mkdir Tasksh
cd Tasksh
dotnet new sln
dotnet new mvc -o Tasksh
dotnet sln add Tasksh
cd Tasksh
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
cd Models	
touch Product.cs
touch Category.cs
echo "namespace Tasksh.Models;
public class Product
{
    public int ProductId { get; set; }

    
}" > Product.cs
echo "namespace Tasksh.Models;
public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int Description { get; set; }

    
}" > Category.cs