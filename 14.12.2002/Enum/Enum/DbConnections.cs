using System.ComponentModel.DataAnnotations;

namespace EnumTask
{
    public enum DbConnections : byte
    {
        [Display(Name = "Server = SQL;Database=Northwind;Uid=SQL123;Pwd=123;")]
        Sql = 1,

        [Display(Name = "Server = MYSQL;Database=Northwind;Uid=MYSQL123;Pwd=123;")]
        MySql = 2,
        [Display(Name = "Server = ORACLE;Database=Northwind;Uid=ORACLE123;Pwd=123;")]
        Oracle = 3
    }
}
