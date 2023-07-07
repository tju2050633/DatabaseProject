system登录sqlplus后：

```sql
create temporary tablespace gd_temp tempfile 'D:\xxx\gd_temp.dbf' size 50m autoextend on next 50m maxsize 20480m;

create tablespace gd_data datafile 'D:\xxx\gd_data.dbf' size 50m autoextend on next 50m maxsize 20480m;

create user C##gd identified by 123456 default tablespace gd_data temporary tablespace gd_temp;

grant connect, resource to C##gd;

grant unlimited tablespace to C##gd;
```

- xxx修改为路径名
- 文件名可以改，但需要是.dbf文件
- 用户名、密码自行设置



C#连接字符串样式(目前位于Garden.DAL/Core/OracleHelper.cs中)：

```c#
 public static string connectionString = "Data Source=localhost:1521/orcl;User Id=C##gd;Password=123456;";
```

